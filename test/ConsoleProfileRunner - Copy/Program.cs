using System;
using Serilog.Parsing;

namespace ConsoleProfileRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            for (int i = 0; i < 1_000_000; i++)
            {
                EmptyTemplate();
                SimpleTextTemplate();
                SinglePropertyTokenTemplate();
                ManyPropertyTokenTemplate();
                MultipleTokensTemplate();
                DefaultConsoleOutputTemplate();
            }

            Console.WriteLine("Ended!");
        }

        static readonly MessageTemplateParser _parser = new MessageTemplateParser();

        const string _SimpleTextTemplate = "Hello, world!";
        const string _SinglePropertyTokenTemplate = "{Name}";
        const string _ManyPropertyTokenTemplate = "{Greeting}, {Name}!";
        const string _MultipleTokensTemplate = "Hello, world! {Greeting}, {Name} - {{Escaped}} - {@Hello} {$World}";
        const string _DefaultConsoleOutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}";

        public static void EmptyTemplate()
        {
            _parser.Parse("");
        }

        public static void SimpleTextTemplate()
        {
            _parser.Parse(_SimpleTextTemplate);
        }

        public static void SinglePropertyTokenTemplate()
        {
            _parser.Parse(_SinglePropertyTokenTemplate);
        }

        public static void ManyPropertyTokenTemplate()
        {
            _parser.Parse(_ManyPropertyTokenTemplate);
        }

        public static void MultipleTokensTemplate()
        {
            _parser.Parse(_MultipleTokensTemplate);
        }

        public static void DefaultConsoleOutputTemplate()
        {
            _parser.Parse(_DefaultConsoleOutputTemplate);
        }
    }
}
