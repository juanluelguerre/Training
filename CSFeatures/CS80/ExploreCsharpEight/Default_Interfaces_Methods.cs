using System;
using System.Collections.Generic;
using System.Text;

namespace ExploreCsharpEight
{
	// Microsoft doc: https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods

	public interface IDisplayService
	{
		// Now in C# 8.0 we can create a default implementation. Now modificator (public | protected | internal | Sealed | Virtual  apply for it  !!!!

		void DisplayMessage(string message) => Console.WriteLine($"Display: {message}");

		// https://github.com/dotnet/csharplang/milestone/11
	}

	public class DisplayService : IDisplayService
	{
		#region CASE 1) --> As usual before C# 8.0

		// Now in C# 8.0 we don't need to implement below (as default) implementation.
		//public void DisplayMessage(string message)
		//{
		//	Console.WriteLine($"Display: {message}");
		//}

		#endregion
	}

	public class Default_Interfaces_Methods
	{
		public void DoSomething()
		{
			Console.WriteLine("Default Implementation On Interfaces");

			#region  CASE 2) -- > ERROR

			//var srv = new DisplayService();
			//srv.DisplayMessage("Hi from C# 8.0");

			#endregion

			#region CASE 3) --> OK

			IDisplayService srv = new DisplayService();
			srv.DisplayMessage("Hi from C# 8.0");

			#endregion


			Console.WriteLine("Press ENTER to finish...");
			Console.ReadLine();
		}
	}
}
