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
        readonly MessageTemplateParserSpanArrNoIn _parserArrNoIn;

        readonly MessageTemplateParserMemoryIterator _parserMemory;
        readonly MessageTemplateParserLexer _parserLexer;

        const string _bigTemplate = "Hello, world! {Greeting}, {Name} - {{Escaped}} - {@Hello} {$World} {Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception} Hello, world!";
        //const string _bigTemplate = "Hello, world! {Greeting}, {Name}!";

        public MessageTemplateParsingBenchmarkCompare()
        {
            _parser = new MessageTemplateParser();
            _parserMods = new MessageTemplateParserWithSmallMods();
            _parserArr = new MessageTemplateParserSpanArr();
            _parserArrNoIn = new MessageTemplateParserSpanArrNoIn();
            _parserMemory = new MessageTemplateParserMemoryIterator();
            _parserLexer = new MessageTemplateParserLexer();
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
        public void MessageTemplateParserSpanArrNoIn()
        {
            _parserArrNoIn.Parse(_bigTemplate);
        }

        [Benchmark]
        public void MessageTemplateParserMemoryIterator()
        {
            _parserMemory.Parse(_bigTemplate);
        }

        [Benchmark]
        public void MessageTemplateParserLexer()
        {
            _parserLexer.Parse(_bigTemplate);
        }
    }
}
