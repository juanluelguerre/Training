//
// Samples from: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7
//
using System.Collections.Generic;
using static System.Console;

namespace FeatruesCS7
{
    class CS7
    {
        static void Main(string[] args)
        {
            WriteLine();
            WriteLine("System.ValueTuple doesn't exist earlier than C# 6.0. Is new in C# 7.0 and upper !!!");
            WriteLine();

            // 1)
            //var letters = new System.ValueTuple<string, string, string>("a", "b", "c");
            var letters = ("a", "b", "c");
            WriteLine($"{letters.Item1}, {letters.Item2}, ....");

            // 2)
            (string Alpha, string Beta) namedLetters = ("a", "b");
            WriteLine($"{namedLetters.Alpha}, {namedLetters.Beta}, ....");

            // 3)
            var alphabetStart = (Alpha: "a", Beta: "b");
            WriteLine($"{alphabetStart.Alpha}, {alphabetStart.Beta}, ....");

            // 4)
            (string First, string Second) firstLetters = (Alpha: "a", Beta: "b");
            WriteLine($"{firstLetters.First}, {firstLetters.Second}, ....");

            // 5) Practical sample
            var numbers = new int[] { 1, 2, 5, 8, 99, 13, 15, 4, 7 };
            var (min, max) = Range(numbers);
            WriteLine($"[{min}, {max}]");

            // var told = RangeOld(numbers);



            // 6) Deconstructor
            Point p = new Point(1.2, 3.2);
            (double x, double y) = p;
            WriteLine($"[{x} / {y}]");


            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }

        private static (int Max, int Min) Range(IEnumerable<int> numbers)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (var n in numbers)
            {
                min = (n < min) ? n : min;
                max = (n > max) ? n : max;
            }
            return (max, min);
        }


        private static System.Tuple<int, int> RangeOld(IEnumerable<int> numbers)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (var n in numbers)
            {
                min = (n < min) ? n : min;
                max = (n > max) ? n : max;
            }
            return System.Tuple.Create<int, int>(min, max);
        }
    }
}
