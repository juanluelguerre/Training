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
        static void DoStuff(ref int parameter)
        {
            // Now otherRef is also a reference, modifications will propagate back
            
            // OK
            ref int otherRef = ref parameter;
            // OK
            ref var otherRef2 = ref parameter;
            
            // NO OK
            // var otherRef = ref parameter;

            // This is just its value, modifying it has no effect on the original
            var otherVal = parameter;
        }

        static void Main(string[] args)
        {
            // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/ref-local-reassignment.md

            Console.WriteLine("Ref Local Reassignment");

            int value1 = 0;

            // 1) Changed value for 'value1' after 'refValue1' changed.
            ref var refValue1 = ref value1;
            refValue1 = 1;

            // 2) no changed value for 'value2'
            value1 = 0;
            var value2 = value1;
            value2 = 2;

            int value3 = 44;
            var value4 = value3;
            value3 = 55;
                
            DoStuff(ref value1);
   

            // 2) 
            var b = new TwoSpans<int>();
            ref var a = ref b;

            //
            // Span<T>: Is a new feature that significantly improves performance.
            //
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
