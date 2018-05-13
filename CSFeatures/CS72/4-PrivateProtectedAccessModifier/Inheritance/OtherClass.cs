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
            Console.WriteLine($"{b.InternalName}");             
        }
    }
}
