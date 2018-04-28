using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.WebSockets;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR.Internal.Protocol;
using SignalRConsole;

namespace SignaRClient
{
    public class Program
    {
		public static async Task Main(string[] args)
		{

			//  var manager = new WebSocketManager();
			//  manager.Run();

			var manager = new SignalRManager();
			await manager.Run();

		}
    }
}
