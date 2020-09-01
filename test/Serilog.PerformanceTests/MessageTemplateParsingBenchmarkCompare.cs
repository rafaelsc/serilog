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
        readonly MessageTemplateParserSpanArrNoIn2 _parserArrNoIn2;

        readonly MessageTemplateParserMemoryIterator _parserMemory;
        readonly MessageTemplateParserLexer _parserLexer;
        readonly MessageTemplateParserLexer2 _parserLexer2;
        readonly MessageTemplateParserLexer3 _parserLexer3;

        readonly MessageTemplateParserWithMoreMods _parserMods2;

        const string _SimpleTextTemplate = "Hello, world!";
        const string _SinglePropertyTokenTemplate = "{Name}";
        const string _SingleTextWithPropertyTemplate = "This is a new Log entry with some external {Data}";
        const string _ManyPropertyTokenTemplate = "{Greeting}, {Name}!";
        const string _MultipleTokensTemplate = "Hello, world! {Greeting}, {Name} - {{Escaped}} - {@Hello} {$World}";
        const string _DefaultConsoleOutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}";
        const string _BigTemplate = "Hello, world! {Greeting}, {Name} - {{Escaped}} - {@Hello} {$World} {Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception} Hello, world! {0} {-1} {2} {Test,-15} {Prop,50} {Qnt,5:000}";


        public MessageTemplateParsingBenchmarkCompare()
        {
            _parser = new MessageTemplateParser();
            _parserMods = new MessageTemplateParserWithSmallMods();
            _parserMods2 = new MessageTemplateParserWithMoreMods();
            _parserArr = new MessageTemplateParserSpanArr();

            _parserArrNoIn = new MessageTemplateParserSpanArrNoIn();
            _parserArrNoIn2 = new MessageTemplateParserSpanArrNoIn2();

            _parserMemory = new MessageTemplateParserMemoryIterator();
            _parserLexer = new MessageTemplateParserLexer();
            _parserLexer2 = new MessageTemplateParserLexer2();
            _parserLexer3 = new MessageTemplateParserLexer3();
        }

        [Benchmark(Baseline = true)]
        public void MessageTemplateParser()
        {
            _parser.Parse(_SimpleTextTemplate);
            _parser.Parse(_SinglePropertyTokenTemplate);
            _parser.Parse(_SingleTextWithPropertyTemplate);
            _parser.Parse(_ManyPropertyTokenTemplate);
            _parser.Parse(_MultipleTokensTemplate);
            _parser.Parse(_DefaultConsoleOutputTemplate);
            _parser.Parse(_BigTemplate);
        }

        //[Benchmark]
        //public void MessageTemplateParserWithSmallMods()
        //{
        //    _parserMods.Parse(_BigTemplate);
        //}
        //[Benchmark]
        //public void MessageTemplateParserWithMoreMods()
        //{
        //    _parserMods2.Parse(_BigTemplate);
        //}

        [Benchmark]
        public void MessageTemplateParserSpanArr()
        {
            _parserArr.Parse(_SimpleTextTemplate);
            _parserArr.Parse(_SinglePropertyTokenTemplate);
            _parserArr.Parse(_SingleTextWithPropertyTemplate);
            _parserArr.Parse(_ManyPropertyTokenTemplate);
            _parserArr.Parse(_MultipleTokensTemplate);
            _parserArr.Parse(_DefaultConsoleOutputTemplate);
            _parserArr.Parse(_BigTemplate);
        }

        [Benchmark]
        public void MessageTemplateParserSpanArrNoIn()
        {
            _parserArrNoIn.Parse(_SimpleTextTemplate);
            _parserArrNoIn.Parse(_SinglePropertyTokenTemplate);
            _parserArrNoIn.Parse(_SingleTextWithPropertyTemplate);
            _parserArrNoIn.Parse(_ManyPropertyTokenTemplate);
            _parserArrNoIn.Parse(_MultipleTokensTemplate);
            _parserArrNoIn.Parse(_DefaultConsoleOutputTemplate);
            _parserArrNoIn.Parse(_BigTemplate);
        }
        [Benchmark]
        public void MessageTemplateParserSpanArrNoIn2()
        {
            _parserArrNoIn2.Parse(_SimpleTextTemplate);
            _parserArrNoIn2.Parse(_SinglePropertyTokenTemplate);
            _parserArrNoIn2.Parse(_SingleTextWithPropertyTemplate);
            _parserArrNoIn2.Parse(_ManyPropertyTokenTemplate);
            _parserArrNoIn2.Parse(_MultipleTokensTemplate);
            _parserArrNoIn2.Parse(_DefaultConsoleOutputTemplate);
            _parserArrNoIn2.Parse(_BigTemplate);
        }

        //[Benchmark]
        //public void MessageTemplateParserMemoryIterator()
        //{
        //    _parserMemory.Parse(_BigTemplate);
        //}

        //[Benchmark]
        //public void MessageTemplateParserLexer()
        //{
        //    _parserLexer.Parse(_BigTemplate);
        //}
        //[Benchmark]
        //public void MessageTemplateParserLexer2()
        //{
        //    _parserLexer2.Parse(_BigTemplate);
        //}
        //[Benchmark]
        //public void MessageTemplateParserLexer3()
        //{
        //    _parserLexer3.Parse(_BigTemplate);
        //}
    }
}
