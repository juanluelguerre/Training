//
// https://docs.microsoft.com/en-us/dotnet/csharp/reference-semantics-with-value-types
//
// https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.2/readonly-ref.md
//
using System;
using System.Drawing;

namespace FeatruesCS72
{
    public class CS72
    {
        static Point _p;

        public static void Main(string[] args)
        {
            int a = 1, b = 2;
            if (TryCalculate(a, b, out int total))
            {
                Console.WriteLine($"Total: {total}");
            }

            Point p1 = new Point(1, 2), p2 = new Point(3, 4), pTotal;

            if (TryCalculatePoint(p1, p2, ref pTotal))
            {
                Console.WriteLine($"Total Point: {pTotal.X}-{pTotal.Y}");
            }

            //var pp = CalculatePoint(p1, p2);

            Console.WriteLine("Pulse INTRO para finalizar...");
            Console.ReadLine();
        }

        static bool TryCalculate(int a, int b, out int total)
        {
            total = a + b;
            return true;
        }

        static bool TryCalculatePoint(Point a, Point b, ref Point total)
        {
            if (a != null && b != null)
            {
                total.X = a.X + b.X;
                total.Y = a.Y + b.Y;

                return true;
            }
            total.X = 0;
            total.Y = 0;
            return false;
        }

        static ref readonly Point CalculatePoint(Point a, Point b)
        {
            if (a != null && b != null)
            {
                _p.X = a.X + b.X;
                _p.Y = a.Y + b.Y;
            }
            return ref _p;
        }
    }

    public class ImmutableArray<T>
    {
        private readonly T[] array;
        private T _current;

        public ref readonly T ItemRef(int i)
        {
            // returning a readonly reference to an array element
            this._current = array[i];
            return ref this._current;

        }
    }
}
