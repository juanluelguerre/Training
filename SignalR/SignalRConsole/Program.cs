using Microsoft.Extensions.Configuration;
using SignalRConsole;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SignaRClient
{
    public class Program
    {
		// private static string DEFAULT_URL = "http://echo.websocket.org/";
        private static string DEFAULT_URL = "http://localhost:3000";

		public static async Task Main(string[] args)
		{
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string url = configuration.GetValue("url", DEFAULT_URL);

            //if (configuration.GetValue<bool>("UseSignalR", true))
            //{
            //    var manager = new SignalRManager(url);
            //    await manager.Run();
            //}
            //else
            //{
            //    var manager = new WebSocketManager(url);
            //    manager.Run();
            //}

            var manager = new SocketIOManager(url);
            manager.Run();

            Console.WriteLine();
            Console.WriteLine("Pulse INTRO para finalizar...");
            Console.ReadLine();            
        }
    }
}
