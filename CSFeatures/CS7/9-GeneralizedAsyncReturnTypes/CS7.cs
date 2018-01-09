using System;
using System.Threading.Tasks;
using static System.Console;

// We need to add the NuGet package System.Threading.Tasks.Extensions in order to use the ValueTask<TResult> type.

namespace FeaturesCS7
{
    public class CS7
    {
        #region  CASE 1) Improving performance

        // Use ValueTask<> instead of Task<> to improve performance. 
        // NuGet: System.Threading.Tasks.Extensions
        public static async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }

        #endregion

        #region CASE 2) Better performance improvements

        public static ValueTask<int> CachedFunc()
        {
            return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
        }
        private static bool cache = false;
        private static int cacheResult;
        private static async Task<int> LoadCache()
        {
            // simulate async work:
            await Task.Delay(100);
            cacheResult = 100;
            cache = true;
            return cacheResult;
        }

        #endregion

        static void Main(string[] args)
        {
            WriteLine("C# 7.0 - Generalized Async Return Types");

            WriteLine($"ValueTask: {Func()}");

            WriteLine($"ValueTask: {CachedFunc()}");
            WriteLine($"ValueTask Cached !!!: {CachedFunc()}");

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}
