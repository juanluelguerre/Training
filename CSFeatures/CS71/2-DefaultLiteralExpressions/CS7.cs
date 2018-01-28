using System;
using static System.Console;

namespace CSFeatures
{
    public class CS7
    {
        public static void Main(string[] args)
        {
            Func<string, bool> where = default(Func<string, bool>);

            bool result = where.Invoke("Hello!");

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}
