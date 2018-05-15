using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SignalRConsole
{
    public class SignalRManager
    {
		private HubConnection _connection;
        private string _url;

        public SignalRManager(string url)
        {
            _url = url;
        }

		public async Task Run()
        {         
            _connection = new HubConnectionBuilder().WithUrl(_url).WithWebSocketOptions(opt =>
            {
                // opt.SetRequestHeader("", "");
                // opt.Cookies = new System.Net.CookieContainer();
                // opt.SetRequestHeader("User-Agent", userAgent);
                // opt.KeepAliveInterval = TimeSpan.FromHours(1);
            })
            .WithConsoleLogger(LogLevel.Debug)
            .WithHeader("Access-Control-Allow-Origin", "*")
            // .WithHubProtocol(new JsonHubProtocol())
            .WithTransport(Microsoft.AspNetCore.Http.Connections.TransportType.WebSockets)                        
            .Build();
            
            try
            {
                var c = _connection.On<string>("connect", (txt) => {
                    Console.WriteLine("CONECTED !");                    
                });

                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection error !!!: {ex.Message}");
            }            
        }      
    }
}
