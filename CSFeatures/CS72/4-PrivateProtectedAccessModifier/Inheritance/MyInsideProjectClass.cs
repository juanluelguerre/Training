using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class MyInsideProjectClass : BaseClass
    {
        public MyInsideProjectClass()
        {
            this._id = 1;            
            this.InternalName = "Juanlu";
            this._PrivateProtectedName = "Guerrero";
        }

        public void Print()
        {
            Console.WriteLine($"{_id},{_PrivateProtectedName}, {InternalName}");
        }
    }
}
