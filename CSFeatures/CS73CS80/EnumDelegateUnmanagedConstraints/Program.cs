using System;
using System.Drawing;

namespace EnumDelegateUnmanagedConstraints
{
    enum Enum1
    {

    }

    public class Program
    {
        // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/blittable.md

        static Enum1 enum1;

        delegate int DelegateSum(int val);

        static void DoSomething1<T>(T value) where T : System.Enum { }
        static void DoSomething2<T>(T value) where T : System.Delegate { }
        static void DoSomething3<T>(T value) where T : unmanaged { }
        
        // Method sample Delegate with no lambda
        static int Sum(int val) => val + 2;


        static void Main(string[] args)
        {
            https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/blittable.md

            Console.WriteLine("System.Enum, System.Delegate and unmanaged constraints");

            //
            // 1)
            //
            DoSomething1(enum1);

            //
            // 2
            //
            // DelegateSum sum = Sum;
            DelegateSum sum = (val) => val + 2;            
            DoSomething2(sum);

            // 
            // 3)
            //
            Int32 a = 56;
            DoSomething3(new Point());  // OK 
            DoSomething3(a);           // OK
            // DoSomething3("hello");  // Error: Type string does not satisfy the unmanaged constraint


            Console.WriteLine("Press ENTER to finalize...");
            Console.ReadLine();
        }
    }
}
