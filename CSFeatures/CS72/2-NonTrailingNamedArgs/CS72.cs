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
            // 1). Especify optional third parameter. The second one has the default value.
            var total = Calculate(1, c: 3);
            total = Calculate(1, c: 2, b: 3); // Changing order

            // 2). Intellisense show "[" and "]" to indicate optional parameters
            // Calculate()

            // 3). Overload resolution
            var total2 = Calculate2(1, 2);
            total2 = Calculate2(1, b: 2);
            total2 = Calculate2(1, c: 4);


            // 4). Apply also to Interfaces COM. ie: Excel API. Clean code when a lot of optional arguments !

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
