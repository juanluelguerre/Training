using System;
using static System.Console;

namespace FeaturesCS7
{
    public class CS7
    {
        static void Main(string[] args)
        {
            WriteLine("C# 7.0 - Numeric Literal Syntax Improvements");

            #region  CASE 1) Binary literals

            const int Sixteen = 0b0001_0000;
            const int ThirtyTwo = 0b0010_0000;
            const int SixtyFour = 0b0100_0000;
            const int OneHundredTwentyEight = 0b1000_0000;

            #endregion

            #region  CASE 2) digit separators

            const long BillionsAndBillions = 100_000_000_000;
            const double AvogadroConstant = 6.022_140_857_747_474e23;
            const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;

            #endregion
            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();

        }
    }
}
