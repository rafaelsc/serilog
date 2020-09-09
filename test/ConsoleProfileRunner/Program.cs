using System;
using System.Linq;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;
using Serilog.Parsing;

namespace ConsoleProfileRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            (new Program()).SimulateAAppWithSerilogOn();

            Console.WriteLine("Ended!");
        }

        const int TodoMainLoopCount = 1_000_000;
        static readonly Random Rnd = new Random(42);

        static readonly LoggingLevelSwitch LoggingLevelSwitch = new LoggingLevelSwitch(LogEventLevel.Verbose);
        readonly ILogger _logger;

        internal Program()
        {
            _logger = CreateLog().ForContext<Program>();
        }

        public void SimulateAAppWithSerilogOff()
        {
            LoggingLevelSwitch.MinimumLevel = LogEventLevel.Fatal; //Just Log Fatal Events and all other Log levels are OFF
            SimulateAAppWithSerilog();
        }

        public void SimulateAAppWithSerilogOn()
        {
            LoggingLevelSwitch.MinimumLevel = LogEventLevel.Verbose; //All Log levels ON
            SimulateAAppWithSerilog();
        }

        static ILogger CreateLog()
        {
            return Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Environment", "BenchmarkTester")
                .Enrich.WithProperty("Application", "Serilog.PerformanceTests.AlmostRealWorldBenchmark")
                .Enrich.WithProperty("ExecutionId", Guid.NewGuid())
                .Enrich.WithProperty("ExecutionStartDate", DateTimeOffset.UtcNow)
                .MinimumLevel.ControlledBy(LoggingLevelSwitch)
                .WriteTo.Logger(l => l
                    .Filter.ByExcluding(ev => ev.Properties.ContainsKey("ProgressEntry"))
                    .WriteTo.Sink(new NullSink())) //To Simulate a FileSink that don't 'records' some LogEvents
                .WriteTo.Sink(new NullSink()) //To Simulate a Console Sink that show all LogEvents
                .CreateLogger();
        }

        void SimulateAAppWithSerilog()
        {
            var log = _logger.ForContext("Prop", "Value");

            log.Information("App - Start...");

            log.Information("Arguments: {@Args}", new[] { "test", "performance", "-q" });
            log.Information("Parsing args.");
            var execType = ExecutionType.Test;

            var log2 = log.ForContext("Type", execType);
            log2.Information("Running in {Type} mode", execType);

            RunTestWithLog(execType, log2);

            log.Information("App - Ending...");
        }

        static int RunTestWithLog(ExecutionType execType, ILogger log)
        {
            var start = DateTimeOffset.UtcNow;
            log.Information("Starting Exec of the Test Begin at {StartDateTime}", start);
            try
            {
                using (LogContext.PushProperty("Operation", "Testing"))
                {
                    var todo = Enumerable.Range(0, TodoMainLoopCount).ToList();
                    var passed = 0;
                    var fail = 0;

                    foreach (var i in todo.LogProgress(log))
                    {
                        using (LogContext.PushProperty("Item", i))
                        {
                            log.Information("Testing... {ItemNumber}", i);

                            var result = (Rnd.Next(0, 1) == 1);
                            if (result)
                            {
                                passed++;
                                log.Information("Test Passed.");
                            }
                            else
                            {
                                fail++;
                                log.Information("Test not Passed.");
                            }

                            log.Information("Item Test End");
                        }
                    }
                    log.Information("Test End");

                    log.Information("Qnt of tests: {QntOfItems}", todo.Count);
                    log.Information("Test Statistics: {@Statistics}", new { Qnt = todo.Count, Passed = passed, Fail = fail });

                    return passed - fail;
                }
            }
            finally
            {
                var end = DateTimeOffset.UtcNow;
                if (log.IsEnabled(LogEventLevel.Information))
                {
                    log.Information($"Exec ended - Elapsed {(end - start)}");
                }
            }
        }

        enum ExecutionType
        {
            Test,
            Build,
            Run,
        }
    }
}
