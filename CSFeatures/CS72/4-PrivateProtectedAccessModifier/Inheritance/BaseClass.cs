using System;

namespace Inheritance
{
    public class BaseClass
    {
        protected int _id;

        private protected string _PrivateProtectedName;

        internal string InternalName { get; set; }

        public string Description { get; set; }


        public BaseClass()
        {
                
        }
    }
}
