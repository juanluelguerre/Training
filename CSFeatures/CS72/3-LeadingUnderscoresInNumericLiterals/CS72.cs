using System;

namespace FeatruesCS72
{
    class CS72
    {
        static void Main(string[] args)
        {
            //
            // 1) Underscore ("_") separator after "0b" (binary identifier) allowed.
            //
            const int Sixteen = 0b_0001_0000;
            const int ThirtyTwo = 0b_0010_0000;
            const int SixtyFour = 0b_0100_0000;
            const int OneHundredTwentyEight = 0b_1000_0000;


            Console.WriteLine("Press ENTER to finalize...");
            Console.ReadLine();
        }
    }
}
