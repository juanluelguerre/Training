using System;

namespace AttributesOnBackingFields
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Attributes On Backing Fields");

            var str = ToYesNoValue(null);

            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }

       

        public static string ToYesNoValue(this bool? value)
        {
            return value.HasValue ?  (value.Value ? "YES" : "NO") : String.Empty;
        }
    }
}
