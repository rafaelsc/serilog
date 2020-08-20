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
        readonly MessageTemplateParserLexer2 _parserLexer2;
        readonly MessageTemplateParserLexer3 _parserLexer3;

        readonly MessageTemplateParserWithMoreMods _parserMods2;

        const string _bigTemplate = "Hello, world! {Greeting}, {Name} - {{Escaped}} - {@Hello} {$World} {Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception} Hello, world! {0} {-1} {2} {Test,-15} {Prop,50} {Qnt,5:000}";
        //const string _bigTemplate = "Hello, world! {Greeting}, {Name}!";

        public MessageTemplateParsingBenchmarkCompare()
        {
            _parser = new MessageTemplateParser();
            _parserMods = new MessageTemplateParserWithSmallMods();
            _parserMods2 = new MessageTemplateParserWithMoreMods();
            _parserArr = new MessageTemplateParserSpanArr();
            _parserArrNoIn = new MessageTemplateParserSpanArrNoIn();
            _parserMemory = new MessageTemplateParserMemoryIterator();
            _parserLexer = new MessageTemplateParserLexer();
            _parserLexer2 = new MessageTemplateParserLexer2();
            _parserLexer3 = new MessageTemplateParserLexer3();


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
        public void MessageTemplateParserWithMoreMods()
        {
            _parserMods2.Parse(_bigTemplate);
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
        [Benchmark]
        public void MessageTemplateParserLexer2()
        {
            _parserLexer2.Parse(_bigTemplate);
        }
        [Benchmark]
        public void MessageTemplateParserLexer3()
        {
            _parserLexer3.Parse(_bigTemplate);
        }
    }
}
