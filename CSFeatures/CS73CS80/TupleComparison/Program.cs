using System;

namespace TupleComparison
{
    public class Program
    {
        static void Main(string[] args)
        {
            //https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/tuple-equality.md

            Console.WriteLine("Tuple Comparision. Support for == and != on tuple types");

            (int name, int surname) tuple1= (1, 2);
            (int, int) tuple2 = (1, 2);

            // Usuary
            if ((tuple1.name  == tuple2.Item1 && tuple1.surname == tuple2.Item2))
            {
                Console.WriteLine("Tuples are equals as usually !");
            }

            // C#7.3
            if (tuple1 == tuple2)
            {
                Console.WriteLine("Now in C# 7.3 is easier: Tuples are equals !");
            }

            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }
    }
}
