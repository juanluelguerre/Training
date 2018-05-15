using System;

namespace StackallocArrayInitializers
{
    class Program
    {
        unsafe static void Fibonacci()
        {
            const int arraySize = 20;
            int* fib = stackalloc int[arraySize];
            int* p = fib;
            // The sequence begins with 1, 1.
            *p++ = *p++ = 1;
            for (int i = 2; i < arraySize; ++i, ++p)
            {
                // Sum the previous two numbers.
                *p = p[-1] + p[-2];
            }

            for (int i = 0; i < arraySize; ++i)
            {
                Console.WriteLine(fib[i]);
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Stackalloc Array Initializers");

            // As usuall, as we know
            var a1 = new int[3];
            var a2 = new int[3] { 1, 2, 3 };
            var a3 = new int[] { 1, 2, 3 };
            var a4 = new[] { 1, 2, 3 };

            //
            // 1)
            //
            // Mark on project (.csproj) property: "allow unsafe code"
            unsafe 
            {
                
                // Note: 'stackalloc' is equivalent to alloc in C language.
                // The 'stackalloc' is used in an unsafe code context to allocate a block of memory on the stack.

                var a5 = stackalloc int[3];  // Currently allowed in C# 5.0 and before

                int* block;
                // The following assignment statement causes compiler errors. You can  
                // use stackalloc only when declaring and initializing a local variable.  
                // 
                // block = stackalloc int[100];

                //
                // 1) C# 7.3. We can use array initializer syntax for stackalloc arrays.
                //
                var a6 = stackalloc int[3] { 1, 2, 3 };
                var a7 = stackalloc int[] { 1, 2, 3 };
                var a8 = stackalloc[] { 1, 2, 3 };
            }
            
            //
            // 2)
            //
            // NetCore 2.1 ('Span<T>')
            Span<int> x = stackalloc[] { 1, 2, 3 };
           

            //
            // 3) 
            //
            Fibonacci();


            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }
    }
}
