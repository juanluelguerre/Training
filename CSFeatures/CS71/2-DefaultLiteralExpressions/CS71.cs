//
// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/default-value-expressions
//
using System;
using static System.Console;

namespace DefaultLiteralExpressions
{
    public class CS71
    {
        public static void Main(string[] args)
        {
            // TODO:  Add project property:  <LangVersion>latest</LangVersion>
            Func<string, bool> where = default;

            bool result = where.Invoke("Hello!");

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}
