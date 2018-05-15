using System;

namespace NullableReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nullable Reference Types");

            // https://msdn.microsoft.com/es-es/magazine/mt829270.aspx

            // Nullable string ????
            // string? text = null;

            // Non nullable string -> !
            // string! text = null;

            // var type = text!.GetType()


            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }
    }
}
