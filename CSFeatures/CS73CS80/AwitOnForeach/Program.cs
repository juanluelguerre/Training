using System;
using System.IO;
using System.Threading.Tasks;

namespace AwitOnForeach
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Use await inside foreach loop !");

            // 1)
            // Stream asyncStream = FileStream.Null;
            // foreach await (var data in asyncStream)
            // {
            //     // Do something
            // }


            // 2)
            // And:  IAsyncEnumerable<T> and IAsyncEnumerator<T> interfaces !!!
            //


            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }
    }
}
