using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            var test = new Test();

            for (int i = 0; i < 100; i++)
            {
                test.LogAll();
            }

            Console.WriteLine("End");
        }
    }
}
