using BenchmarkDotNet.Attributes;
using Serilog.Parsing;

namespace Serilog.PerformanceTests
{
    /// <summary>
    /// Tests the cost of parsing various message templates.
    /// </summary>
    [MemoryDiagnoser]
    public class MessageTemplateParsingBenchmarkCompare
    {
        readonly MessageTemplateParser _parser;
        readonly MessageTemplateParserWithSmallMods _parserMods;
        readonly MessageTemplateParserSpanArr _parserArr;
        
        const string _bigTemplate = "Hello, world! {Greeting}, {Name} - {{Escaped}} - {@Hello} {$World} {Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception} Hello, world!";

        public MessageTemplateParsingBenchmarkCompare()
        {
            _parser = new MessageTemplateParser();
            _parserMods = new MessageTemplateParserWithSmallMods();
            _parserArr = new MessageTemplateParserSpanArr();
        }

        [Benchmark(Baseline = true)]
        public void MessageTemplateParser()
        {
            _parser.Parse(_bigTemplate);
        }

        [Benchmark]
        public void MessageTemplateParserWithSmallMods()
        {
            _parserMods.Parse(_bigTemplate);
        }

        [Benchmark]
        public void MessageTemplateParserArr()
        {
            _parserArr.Parse(_bigTemplate);
        }

    }
}
