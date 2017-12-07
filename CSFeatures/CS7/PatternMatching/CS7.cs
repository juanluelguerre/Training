
//Samples from: https://docs.microsoft.com/es-es/dotnet/csharp/pattern-matching

using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace FeatruesCS7
{
    class CS7
    {
        static void Main(string[] args)
        {

            WriteLine($"Is:\t\t\t{ComputeAreaImprovedIs(new Square(14.5))}");
            WriteLine($"Swith:\t\t\t{ComputeAreaSwitch(new Square(14.5))}");
            WriteLine($"Swith & When:\t\t{ComputeAreaWhen(new Square(14.5))}");
            WriteLine($"Swith & When & Null:\t{ComputeAreaWhenAndNull(new Square(14.5))}");

            //var intNumbers = new int[] { 1, 2, 4, 5, 8, 12, 99, 24, 3 };

            //var result1 = SumaDados(intNumbers);
            //WriteLine($"{result1}");

            //var objNumbers = new object[] { 1, 2, 3, new int[] { 2, 1, 3 }, 4, 5 };
            //var result2 = SumaDados2(objNumbers);
            //WriteLine($"{result2}");


            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }

        // 1) Is
        public static double ComputeAreaImprovedIs(object shape)
        {
            if (shape is Square s)
                return s.Side * s.Side;
            else if (shape is Circle c)
                return c.Radius * c.Radius * Math.PI;
            else if (shape is Rectangle r)
                return r.Height * r.Length;
            // elided
            throw new ArgumentException(
                message: "shape is not a recognized shape",
                paramName: nameof(shape));
        }

        // 2) Switch
        public static double ComputeAreaSwitch(object shape)
        {
            switch (shape)
            {
                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Rectangle r:
                    return r.Height * r.Length;
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }

        // 3) Swith using "when" 
        public static double ComputeAreaWhen(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Triangle t:
                    return t.Base * t.Height * 2;
                case Rectangle r:
                    return r.Length * r.Height;
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }

        // 4) Swith using "when" using null special case
        public static double ComputeAreaWhenAndNull(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Triangle t:
                    return t.Base * t.Height * 2;
                case Rectangle r:
                    return r.Length * r.Height;
                case null:
                    throw new ArgumentNullException(paramName: nameof(shape), message: "Shape must not be null");
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }


        //public static int SumaDados(IEnumerable<int> values)
        //{
        //    return values.Sum();
        //}

        //// 2) if + is statement
        //public static int SumaDados2(IEnumerable<object> values)
        //{
        //    var sum = 0;
        //    foreach (var item in values)
        //    {
        //        if (item is int val)
        //            sum += val;
        //        else if (item is IEnumerable<object> subList)
        //            sum += SumaDados2(subList);
        //    }
        //    return sum;
        //}

        //// 3) switch statement
        //public static int SumaDados3(IEnumerable<object> values)
        //{
        //    var sum = 0;
        //    foreach (var item in values)
        //    {
        //        switch (item)
        //        {
        //            case int val:
        //                sum += val;
        //                break;
        //            case IEnumerable<object> subList:
        //                sum += SumaDados3(subList);
        //                break;
        //        }
        //    }
        //    return sum;
        //}

        //// 4) switch statement usen "when" operator and null case 
        //public static int SumaDados4(IEnumerable<object> values)
        //{
        //    var sum = 0;
        //    foreach (var item in values)
        //    {
        //        switch (item)
        //        {
        //            case 0:
        //                break;
        //            case int val:
        //                sum += val;
        //                break;
        //            case IEnumerable<object> subList when subList.Any():
        //                sum += SumaDados4(subList);
        //                break;
        //            case IEnumerable<object> subList:
        //                break;
        //            case null: // null special case
        //                break;
        //            default:
        //                throw new InvalidOperationException("unknown item type");
        //        }
        //    }
        //    return sum;
        //}


        //// 5) switch statement usen "when" operator and null case 
        //public static int DiceSum5(IEnumerable<object> values)
        //{
        //    var sum = 0;
        //    foreach (var item in values)
        //    {
        //        switch (item)
        //        {
        //            case 0:
        //                break;
        //            case int val:
        //                sum += val;
        //                break;
        //            case PercentileDie die:
        //                sum += die.Multiplier * die.Value;
        //                break;
        //            case IEnumerable<object> subList when subList.Any():
        //                sum += DiceSum5(subList);
        //                break;
        //            case IEnumerable<object> subList:
        //                break;
        //            case null:
        //                break;
        //            default:
        //                throw new InvalidOperationException("unknown item type");
        //        }
        //    }
        //    return sum;
        //}
    }
}
