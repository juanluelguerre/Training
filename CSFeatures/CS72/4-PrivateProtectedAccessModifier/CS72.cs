//
// https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/private-protected
// 
using Inheritance;
using System;
using System.Drawing;

namespace FeatruesCS72
{
    public class CS72
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Press ENTER to finalize...");
            Console.ReadLine();
        }

    }

    // 1) "private protected"
    //    Works using  Compile with: /target:library  but no using /reference:Assembly1.dll  
    public class MyClass : BaseClass
    {
        public MyClass()
        {
            this._id = 1;
            // this._name = ""; ????
            // this._surname = ""; ???
        }
    }
}
