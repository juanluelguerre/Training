using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class OtherClass
    {
        public OtherClass()
        {

        }

        public void Print()
        {
            BaseClass b = new BaseClass();
            Console.WriteLine($"{b.Description}");
            Console.WriteLine($"{b.InternalName}"); // Because we are in the same assembly.

            // NO OK
            // Console.WriteLine($"{b._PrivateProtectedName}"); // No OK. It's a Private Protected Access
        }
    }
}
