using System;

namespace FeatruesCS72
{
    class Program
    {
        static void Main(string[] args)
        {
            // Before, in C# 7.0 / 7.1
            const int Sixteen = 0b0001_0000;
            const int ThirtyTwo = 0b0010_0000;
            const int SixtyFour = 0b0100_0000;
            const int OneHundredTwentyEight = 0b1000_0000;


            //
            // 1) Underscore ("_") separator after "0b" (binary identifier) allowed.
            //
            const int Sixteen_8 = 0b_0001_0000;
            const int ThirtyTwo_8 = 0b_0010_0000;
            const int SixtyFour_8 = 0b_0100_0000;
            const int OneHundredTwentyEight_8 = 0b_1000_0000;


            Console.WriteLine("Press ENTER to finalize...");
            Console.ReadLine();
        }
    }
}
