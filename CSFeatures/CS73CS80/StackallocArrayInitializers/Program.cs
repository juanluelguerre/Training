using System;

namespace StackallocArrayInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stackalloc Array Initializers");

            // NetCore 2.1
            Span<int> x = stackalloc[] { 1, 2, 3 };

            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }
    }
}
