using System;

namespace RefLocalReassignment
{
    // Net Core 2.1
    ref struct TwoSpans<T>
    {
        // can have ref-like instance fields
        public Span<T> first;
        public Span<T> second;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/ref-local-reassignment.md

            Console.WriteLine("Ref Local Reassignment");

            var b = new TwoSpans<int>();
            ref var a = ref b;


            var arr = new byte[10];
            Span<byte> bytes = arr; // Implicit cast from T[] to Span<T>

            // Net Core 2.1
            // error: arrays of ref-like types are not allowed. 
            // TwoSpans<T>[] arr = null;


            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }
    }
}
