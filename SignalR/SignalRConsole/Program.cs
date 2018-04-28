using System;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignaRClient
{
    public class Program
    {
		private static HubConnection _connection;
        // private static string URL = "http://localhost:5002/hubs";
        private static string URL = "http://localhost:3000";
        //private static string WSURL = "ws://localhost:3000";
        //private static string WSURL = "ws://MacGuerre.local:82/codegame-beta";

        public static async Task Main(string[] args)
		{

            // await RunWebSockets(WSURL);
            //return;

            //Configure(URL);

            _connection = new HubConnectionBuilder().WithUrl(URL).WithWebSocketOptions(opt =>
            {
                //opt.
            })
            .WithConsoleLogger()
            .WithTransport(Microsoft.AspNetCore.Http.Connections.TransportType.WebSockets)
            .Build();
            
            try
            {
                var c = _connection.On<string>("connect", async (txt) => {
                     
                     Console.WriteLine("CONECTED !"); 
                     await _connection.SendAsync("login", "Test User", "1234");
                     });
                await _connection.StartAsync();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"Connection error !!!: {ex.Message}");
                System.Console.WriteLine();
            }


            //await _connection.SendAsync("login", "Test User", "1234");
            // await _connection.SendAsync("login", new { name = "Test User", password="1234" });



			// bool connected = await Connect();
            // if (connected)
            // {
            //     string msg = "Hello World !";
            //     bool msgsent = await SendMessage("SendToGroug", msg);

            //     bool end = false;
            //     while (!end)
            //     {           
            //         msg = Console.ReadLine();
            //         if (msg.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            //             end = true;
            //         else
            //         {
            //             msgsent = await SendMessage(msg);
            //             if (! msgsent)
            //                 Console.WriteLine("Mesage cannot be sent !");
            //         }
            //     }
                        
            //     await Disconnect();
            // }
            // else
            // {
            //     Console.WriteLine();
            //     Console.WriteLine($"Error connecting to {URL}");
            //     Console.WriteLine();                
            // }
		}

        private static async Task<bool> SendMessage(string message)
        {
            return await SendMessage("Send", message);
        }

        private static async Task<bool> SendMessage(string methodName, string message)
        {
            bool sent = false;
            try
            {
				await _connection.SendAsync(methodName, message);
                sent = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
            }
            return sent;
        }

		private static void Configure(string url)
		{
			_connection = new HubConnectionBuilder()
				.WithUrl(url)
			   .Build();
          
            _connection.On<string>("send", (txt) => { Console.WriteLine(txt); });
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
                Console.WriteLine($"ERROR: {ex.StackTrace}");
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


        private static async Task RunWebSockets(string url)
        {
            var ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri(url), CancellationToken.None);

            Console.WriteLine("Connected");

            var sending = Task.Run(async () =>
            {
                string line;
                while ((line = Console.ReadLine()) != null)
                {
                    var bytes = Encoding.UTF8.GetBytes(line);
                    await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, cancellationToken: CancellationToken.None);
                }

                await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
            });

            var receiving = Receiving(ws);

            await Task.WhenAll(sending, receiving);
        }

        private static async Task Receiving(ClientWebSocket ws)
        {
            var buffer = new byte[2048];

            while (true)
            {
                var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, result.Count));
                }
                else if (result.MessageType == WebSocketMessageType.Binary)
                {
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    break;
                }

            }
        }
    }
}
