//
// Samples from: https://docs.microsoft.com/es-es/dotnet/csharp/pattern-matching
//
using System;
using static System.Console;

namespace FeatruesCS7
{
    class CS6
    {
        public static void Main(string[] args)
        {
            var figure1 = ComputeAreaClasic(new Square(15.5));
            WriteLine($"Square area: {figure1}");


            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }

        public static double ComputeAreaClasic(object shape)
        {
            if (shape is Square)
            {
                var s = shape as Square;
                return s.Side * s.Side;
            }
            else if (shape is Circle)
            {
                var c = shape as Circle;
                return c.Radius * c.Radius * Math.PI;
            }
            throw new ArgumentException(
                message: "shape is not a recognized shape",
                paramName: nameof(shape));
        }
    }
}
