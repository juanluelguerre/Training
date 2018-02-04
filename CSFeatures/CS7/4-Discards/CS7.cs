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
            var numbers = new int[] { 1, 2, 5, 8, 99, 13, 15, 4, 7 };

            // Discard
            var (_, min) = Range(numbers);
            WriteLine($"Min: {min}");

            var quotient = Divide(1, 2, out double _);
            WriteLine($"Division result: {quotient}");
            //WriteLine($"Division rest: {rest}");


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

        private static double Divide(double dividend, double divisor, out double rest)
        {
            rest = dividend % divisor;
            return dividend / divisor;
        }
    }
}

