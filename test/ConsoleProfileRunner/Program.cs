using System;
using Serilog.PerformanceTests;

namespace ConsoleProfileRunner
{
    class Program
    {
        const int TodoMainLoopCount = 100;
        //static readonly Random Rnd = new Random(42);

        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            //var b = new MessageTemplateRenderingBenchmark();
            //for (int i = 0; i < TodoMainLoopCount; i++)
            //{
            //    b.NoMessage();
            //    b.NoProperties();
            //    b.OneSimpleProperties();
            //    b.VariedProperties();
            //    b.ComplexProperties();
            //}

            //var b = new PipelineBenchmark();
            //for (int i = 0; i < TodoMainLoopCount; i++)
            //{
            //    b.EmitLogEventWith1Enrich1ForContext1LogContext();
            //    b.EmitLogEventWith10Enrich10ForContext10LogContext();
            //}

            var b = new AlmostRealWorldBenchmark();
            for (int i = 0; i < TodoMainLoopCount; i++)
            {
                b.SimulateAAppWithSerilogOn();
            }

            Console.WriteLine("Ended!");
        }
    }
}
