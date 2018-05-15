using System;

namespace DefaultImplementationOnInterfaces
{
    public class DisplayService : IDisplayService
    {
        // Now in C# 8.0 we don't need to implement below (as default) implementation.
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"Display: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Default Implementation On Interfaces");

            var srv = new DisplayService();
            srv.DisplayMessage("Hi from C# 8.0");


            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }
    }
}
