using System;
using System.Linq;

namespace ExpressionVariablesInInitializers
{
    //
    // 1
    //
    public class A
    {
        public A(int i) { }
        public static int Magic = int.TryParse("123", out var i) ? i : 0;
    }

    public class B : A
    {
        public B(string s)
            : base(int.TryParse(s, out var i) ? i : 0) { }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/expression-variables-in-initializers.md

            Console.WriteLine("Expression variables in Initializers");

            //
            // 2)
            //
            var strings = new string[1];
            var r = from s in strings
                    select int.TryParse(s, out var i);


            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }
    }
}
