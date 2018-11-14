using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            //var test = new Test();

            //for (int i = 0; i < 1; i++)
            //{
            //    test.LogAll();
            //}

            var x = new AlmostRealWorldBenchmark();
            x.LogLikeAApp();

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
