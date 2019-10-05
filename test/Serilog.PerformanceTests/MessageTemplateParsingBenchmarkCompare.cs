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
        readonly MessageTemplateParserMemoryIterator _parserMemory;

        const string _bigTemplate = "Hello, world! {Greeting}, {Name} - {{Escaped}} - {@Hello} {$World} {Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception} Hello, world!";

        public MessageTemplateParsingBenchmarkCompare()
        {
            _parser = new MessageTemplateParser();
            _parserMods = new MessageTemplateParserWithSmallMods();
            _parserArr = new MessageTemplateParserSpanArr();
            _parserMemory = new MessageTemplateParserMemoryIterator();
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
        public void MessageTemplateParserSpanArr()
        {
            _parserArr.Parse(_bigTemplate);
        }

        [Benchmark]
        public void MessageTemplateParserMemoryIterator()
        {
            _parserMemory.Parse(_bigTemplate);
        }
    }
}
