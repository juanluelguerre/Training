using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignaRClient
{
    public class Program
    {
		private static HubConnection _connection;
        private static string URL = "http://localhost:5002/hubs";

        public static async Task Main(string[] args)
		{
			Configure(URL);
			bool connected = await Connect();
            if (connected)
            {
                string msg = "Hello World !";
                bool msgsent = await SendMessage(msg);

                bool end = false;
                while (!end)
                {           
                    msg = Console.ReadLine();
                    if (msg.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                        end = true;
                    else
                    {
                        msgsent = await SendMessage(msg);
                        if (! msgsent)
                            Console.WriteLine("Mesage cannot be sent !");
                    }
                }
                        
                await Disconnect();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Error connecting to {URL}");
                Console.WriteLine();                
            }
		}

		private static void Configure(string url)
		{
			_connection = new HubConnectionBuilder()
				.WithUrl(url)
			   .Build();
          
            _connection.On<string>("Send", (txt) => { Console.WriteLine(txt); });
		}
        
		private static async Task<bool> Connect()
        {
            bool connected = false;
            try
            {
				await _connection.StartAsync();
                connected = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.StackTrace}");
                // Console.WriteLine($"ERROR: {ex.Message}");
            }
            return connected;
        }


        private static async Task Disconnect()
		{
			try
            {
                await _connection.StopAsync();
            }
            catch (Exception ex)
            {
				Debug.WriteLine($"ERROR: {ex.Message}"); 
			}
		}
       
		private static async Task<bool> SendMessage(string message)
        {
            bool sent = false;
            try
            {
				await _connection.SendAsync("Send",  message);
                sent = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
            }
            return sent;
        }
        
    }
}
