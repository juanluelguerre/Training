using System;
using static System.Console;

namespace FeatruesCS71
{
    public class CS71
    {
        public static void Main(string[] args)
        {
            // TODO:  Add project property:  <LangVersion>latest</LangVersion>


            int count = 5;
            string label = "Colors used in the map";
            var pair = (count, label); // element names are "count" and "label"

            //
            //  BUG: C# 7.1 Features !!!
            //  1) Sintaxis error but compilation is OK  (at lest in MAC)!
            //  2) Intellisense same thing
            //
            WriteLine($"Tuple: {pair.count} - {pair.label}");
                
            WriteLine("Pulse INTRO para finalizar...");
            ReadLine();

        }
    }
}
