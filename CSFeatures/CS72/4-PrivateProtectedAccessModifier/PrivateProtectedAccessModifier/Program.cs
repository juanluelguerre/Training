//
// https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/private-protected
// 
using Inheritance;
using System;
using System.Drawing;

namespace FeatruesCS72
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ===============
            //Access modifiers
            //================

            // [public]
            // The type or member can be accessed by any other code in the same assembly or another assembly 
            // that references it.

            // [private]
            // The type or member can only be accessed by code in the same class or struct.

            // [protected]
            // The type or member can only be accessed by code in the same class or struct, or in a derived class.

            // [internal]
            // The type or member can be accessed by any code in the same assembly, but not from another assembly.

            // [protected internal]
            // The type or member can be accessed by any code in the same assembly, or by any derived class 
            // in another assembly.


            // [private protected]
            // Derived and Same Assembly.
            // Works using  Compile with: /target:library but no using /reference:Assembly1.dll  

            Console.WriteLine();
            Console.WriteLine("Private Protected Access Modifier");
            Console.WriteLine("Nothing to do here. Just look internally how it woks.");
            //
            // 1)
            Console.WriteLine("Look Inheritance assembly and see how 'BaseClass' and 'MyInsedeProjectClass' Work together.");
            //
            // 2):
            Console.WriteLine("Look 'MyClass' and see how 'BaseClass' works here.");
            //

            Console.WriteLine();
            Console.WriteLine("Press ENTER to finalize...");
            Console.ReadLine();
        }
    }

    //
    // 1) "private protected"
    //    Works using  Compile with: /target:library  but no using /reference:Assembly1.dll  
    public class MyClass : BaseClass
    {
        public MyClass()
        {
            this._id = 1;
        }

        public void Print()
        {            
            Console.WriteLine($"{this._id}");
            Console.WriteLine($"{this.Description}");

            // NO OK
            // Console.WriteLine($"{this._PrivateProtectedName}");

            // NO OK
            // Console.WriteLine($"{this.InternalName}");
        }
    }
}
