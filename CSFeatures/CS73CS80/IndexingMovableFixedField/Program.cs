using System;

namespace IndexingMovableFixedField
{
    //
    // 1) Compiling with unsafe. Check on project property
    //
    unsafe struct S
    {
        public fixed int MyFixedField[10];
    }

    class Program
    {
        // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/indexing-movable-fixed-fields.md

        static S s;

        unsafe static void Main()
        {
            // Allow indexing fixed fields in movable contexts without pinning
            Console.WriteLine("Indexing Movable Fixed Field");

            int p = s.MyFixedField[5]; // indexing fixed-size array fields would be ok


            //int* ptr = s.MyFixedField; // taking a pointer explicitly still requires pinning.
            //int p2 = ptr[5];


            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }
    }
}
