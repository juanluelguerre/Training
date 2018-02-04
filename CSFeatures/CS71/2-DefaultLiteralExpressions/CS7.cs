// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/default-value-expressions

using System;
using static System.Console;

namespace FeatruesCS71
{
    public class CS7
    {
        public static void Main(string[] args)
        {
            var s = default(string);
            var d = default(dynamic);
            var i = default(int);
            var n = default(int?);
            GenericList<int> list = default(GenericList<int>);
            var list2 = default(GenericList<int>);

            var nValue = n.HasValue ? n.Value.ToString() : "null";
            WriteLine("Nullable Int {0}", nValue);
                

            Func<string, bool> where = default(Func<string, bool>);
            bool result = where.Invoke("Hello!");

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}