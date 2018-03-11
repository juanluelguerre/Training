// Samples from: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1
using static System.Console;
using System.Threading.Tasks;

namespace FeatruesCS71
{
    public class CS7
    {
        public static void Main(string[] args)
        {
            WriteLine("--- Async Main Method ---");

            DoWorkAsync().GetAwaiter().GetResult();

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }

        private static async Task DoWorkAsync() => await Task.CompletedTask;
    }
 }
