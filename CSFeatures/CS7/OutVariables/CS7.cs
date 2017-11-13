//
// Samples from: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7
//
using static System.Console;

namespace FeatruesCS7
{
    class CS7
    {
        static void Main(string[] args)
        {
            string strArgument = "123";

            if (int.TryParse(strArgument, out int numericResult))
                WriteLine(numericResult);
            else
                WriteLine("Could not parse input");

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}
