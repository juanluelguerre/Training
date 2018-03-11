////
//// https://docs.microsoft.com/en-us/dotnet/csharp/reference-semantics-with-value-types
////
//using System;
//using System.Drawing;

//namespace FeatruesCS72
//{
//    public class CS71
//    {
//        static void Main(string[] args)
//        {
//            int a = 1, b = 2;
//            if (TryCalculate(ref a, ref b, out int total))
//            {
//                Console.WriteLine($"Total: {total}");
//            }

//            Point p1, p2;
//            if (TryCalculatePoint(p1, p2, out Point pTotal))
//            {
//                Console.WriteLine($"Total Point: {pTotal.X}-{pTotal.Y}");
//            }

//            Console.WriteLine("Press ENTER to finalize...");
//        }


//        static bool TryCalculate(ref int a, ref int b, out int total)
//        {
//            total = a + b;
//            return true;
//        }

//        static bool TryCalculatePoint(Point a, Point b, out Point total)
//        {
//            if (a != null && b != null)
//            {
//                total.X = a.X + b.X;
//                total.Y = a.Y + b.Y;

//                return true;
//            }
//            total.X = 0;
//            total.Y = 0;
//            return false;
//        }
//    }
//}
