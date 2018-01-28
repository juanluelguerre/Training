//
// Samples from: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1
//
using System.Threading.Tasks;
using static System.Console;

namespace FeatruesCS7
{
    public class CS71
    {        
        // TODO:  Add project property:  <LangVersion>latest</LangVersion>

        public static async Task Main(string[] args)
        {
            WriteLine("--- Async Main Method CS 7.1 ---");
            WriteLine("Pulse INTRO para finalizar...");

            await Task.CompletedTask;
            ReadLine();
        }
    }
}
