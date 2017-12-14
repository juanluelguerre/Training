using System;
using System.Threading.Tasks;
using static System.Console;

// We need to add the NuGet package System.Threading.Tasks.Extensions in order to use the ValueTask<TResult> type.

namespace FeaturesCS7
{
    public class CS6
    {
        public static void Main(string[] args)
        {
            WriteLine("C# 7.0 - Generalized Async Return Types");

            Task.Run(() => PrintValues());

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }

        private static async Task PrintValues()
        {
            var dm = new DataManager();
            var r1 = await dm.Func();
            WriteLine($"{r1}");

            var r2 = await dm.CachedFunc();
            WriteLine($"{r2}");

            var r2cached = await dm.CachedFunc();
            WriteLine($"{r2cached}");
        }
    }

    public class DataManager
    {
        public async Task<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }

        public Task<int> CachedFunc()
        {
            return (cache) ? new Task<int>(() => cacheResult) : LoadCache();
        }
        private bool cache = false;
        private int cacheResult;

        public int Value => cacheResult;

        private async Task<int> LoadCache()
        {
            // simulate async work:
            await Task.Delay(100);
            cacheResult = 100;
            cache = true;
            return cacheResult;
        }
    }
}
