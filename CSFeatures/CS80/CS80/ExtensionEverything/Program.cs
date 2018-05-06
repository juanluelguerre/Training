//
// https://blog.ndepend.com/c-8-0-features-glimpse-future/
//
using System;

namespace ExtensionEverything
{
    public class Program
    {     
        public static void Main(string[] args)
        {
			int i = 0;

			// 1) Current extensión. But only works for METHODS. What about params, properties, ...
			var even = i.IsEven(); 

			// 2) New en C# 8.0. New type declaration called an “extension”:




            Console.WriteLine("Press ENTER to finalize...");
            Console.ReadLine();
        }
    }
}
