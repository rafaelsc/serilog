using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Serilog.PerformanceTests.Support
{
    public static class LogProgressExtension
    {
        public static IEnumerable<TSource> LogProgressWithoutTotal<TSource>(this IEnumerable<TSource> source, ILogger logger, int logAfterXItems = 500, string messageTemplate = "Job Progress...")
        {
            var currentProgress = 0L;
            foreach (var item in source)
            {
                logger.LogProgressWithoutTotal(++currentProgress, logAfterXItems, messageTemplate);
                yield return item;
            }
            logger.ForContext("ProgressEntry", true).Debug($"{messageTemplate} Completed");
        }

        public static IEnumerable<TSource> LogProgress<TSource>(this IEnumerable<TSource> source, ILogger logger, int logAfterXItems = 500, string messageTemplate = "Job Progress...")
        {
            switch (source)
            {
                case ICollection<TSource> collectionOfT:
                    {
                        var count = collectionOfT.Count;
                        return LogProgress(source, logger, count, logAfterXItems, messageTemplate);
                    }
                case ICollection collection:
                    {
                        var count = collection.Count;
                        return LogProgress(source, logger, count, logAfterXItems, messageTemplate);
                    }
                default:
                    {
                        return LogProgressWithoutTotal(source, logger, logAfterXItems, messageTemplate);
                    }
            }
        }

        public static IEnumerable<TSource> LogProgress<TSource>(this ICollection<TSource> source, ILogger logger, int logAfterXItems = 500, string messageTemplate = "Job Progress...")
        {
            return LogProgress(source, logger, source.Count, logAfterXItems, messageTemplate);
        }

        public static IEnumerable<TSource> LogProgress<TSource>(this IEnumerable<TSource> source, ILogger logger, long totalNumberOfItems, int logAfterXItems = 500, string messageTemplate = "Job Progress...")
        {
            return source.Select((item, idx) =>
            {
                var progress = idx + 1;
                LogProgress(logger, progress, totalNumberOfItems, logAfterXItems, messageTemplate);

                return item;
            });
        }

        public static void LogProgress(this ILogger logger, long currentProgress, long totalNumberOfItems, int logAfterXItems = 500, string messageTemplate = "Job Progress...")
        {
            var progress = currentProgress;
            if (progress == 1 || progress % logAfterXItems == 0 || progress == totalNumberOfItems)
            {
                logger.ForContext("ProgressEntry", true).Debug($"{messageTemplate} {{Current}} of {{Total}} - {{Percentage:P1}}", progress, totalNumberOfItems, (progress / (double)totalNumberOfItems));
            }
        }

        public static void LogProgressWithoutTotal(this ILogger logger, long currentProgress, int logAfterXItems = 500, string messageTemplate = "Job Progress...")
        {
            var progress = currentProgress;
            if (progress == 1 || progress % logAfterXItems == 0)
            {
                logger.ForContext("ProgressEntry", true).Debug($"{messageTemplate} {{Current}} of {{Total}}", progress, "?");
            }
        }
    }
}
