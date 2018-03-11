// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/default-value-expressions
using System;
using static System.Console;

namespace FeatruesCS71
{
    public class CS71
    {
        public static void Main(string[] args)
        {
            // TODO:  Add project property:  <LangVersion>latest</LangVersion>

            var s = default(string);
            var d = default(dynamic);
            var i = default(int);
            var n = default(int?);
            GenericList<int> list1 = default(GenericList<int>);
            var list2 = default(GenericList<int>);          


            // (1) Omit the type when use default in the righ side
            GenericList<int> list3 = default;
            Func<string, bool> where = default;


            // (2) default VS default(T) VS default !!!!
            var test1 = 1;
            switch (test1)
            {
                case 1:
                    WriteLine("Do Something");
                    break;

                default:  // (2) default VS default !!!!
                    WriteLine("Nothing to do !");
                    break; 
            }

            bool result = where.Invoke("Hello!");

            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();
        }
    }
}
