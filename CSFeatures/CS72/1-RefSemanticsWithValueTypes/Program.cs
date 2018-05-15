//
// https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.2/readonly-ref.md
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;

namespace FeatruesCS72
{
    public class Program
    {
        static int _total;
        static Point _p;

        public static void Main(string[] args)
        {
            Console.WriteLine("Ref Semantics With Values Types");

            // 
            // 1) "in"
            //  
            // Operation using out argument and "in" params for a, b
            // "in" params (for method) is similar as readonly for properties
            int a = 1, b = 2;
            if (TryCalculate(a, b, out int total))
            {
                Console.WriteLine($"Total: {total}");
            }

            //
            // 2) As Indexer
            //
            // TValue this[in TKey index];
            //ImmutableArray<int> dic = new ImmutableArray<int>();
			//int key = 2;
            //var value = dic[in key]; // in argument to an indexer

            //
            // 3)   "ref readonly". Leverages the efficiency of passing variables by reference, 
            //      but without exposing the data to modifications.
            //
            var c = TryCalculateRefReadOnly(ref a, ref b);

            //
            // 4) Simple operation using ref argument
            //
            Point p1 = new Point(1, 2), p2 = new Point(3, 4), pTotal;           
            if (TryCalculatePoint(p1, p2, ref pTotal))
            {
                Console.WriteLine($"Total Point: {pTotal}");
            }

            var totalRefReadOnly = TryCalculatePoint(p1, p2);

            //
            // 5) And also we can use "in" with operators:
            //
            // public static Vector3 operator +(in Vector3 x, in Vector3 y) => ... // operator

            Console.WriteLine($"Total Ref ReadOnly: {totalRefReadOnly}");
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }

        //static int Sum10(in Func<int, int> predicate)
        //{
        //    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //    return numbers.Sum(n => predicate(n));
        //}

        //
        // 1) "in". As Readonly parameters
        //
        static bool TryCalculate(in int a, in int b, out int total)
        {
            // "in" params cannot be modified inside de method
            // a = a + 1;
            // b = b + 1;

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

        //
        // 2) "ref readonly"
        //
        static ref readonly int TryCalculateRefReadOnly(ref int a, ref int b)
        {
            a = a + 1;
            b = b + 1;
            _total = a + b; // in this sample, '_total' have to be a class member

            return ref _total;
        }

        static ref readonly Point TryCalculatePoint(Point a, Point b)
        {
            _p.X = 0;
            _p.Y=0;

            if (a != null && b != null)
            {
                _p.X = a.X + b.X;
                _p.Y = a.Y + b.Y;
            }
            
            return ref _p; // in this sample _p have to be class member
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

        public T this[in int key]
        {
            get
            {
                _current = array[key];
                return _current;
            }
        }
    }
}
