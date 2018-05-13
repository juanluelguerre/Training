//
// https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
//
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatruesCS72
{
    class CS72
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Non Trainling Named Args");

            // Overload with default params
            var total = Calculate(1, 2, 3);

            total = Calculate(a: 1, b: 2, c: 3);

            total = Calculate(a: 1, c: 3, b: 2); // Changing order       

            // And also
            total = Calculate2(1, 2);
            total = Calculate2(1, b: 2);

            // But those not work for C# 7.1. Here we have to explicit name params for all of them
            // total = Calculate2(1, b: 4, 2);
            // total = Calculate2(1, c: 4, 2);

            // C# 7.2 & Upper
            total = Calculate2(1, b: 4, 2);            


            Console.WriteLine("Press ENTER to finalize...");
            Console.ReadLine();
        }

        static int Calculate(int a, int b = 0, int c = 0)
        {
            return a + b + c;
        }

        static int Calculate2(int a, int b = 0, int c = 0) => a + b + c;

        static int Calculate2(int a, int b = 0) => a + b;

    }
}
