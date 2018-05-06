using PureWebSockets;
using System;
using System.Net.WebSockets;
using System.Threading;

namespace SignalRConsole
{
    public class WebSocketManager
    {
		private PureWebSocket _ws;
        private string _url;

        public WebSocketManager(string url)
        {
            _url = url;
        }

        public void Run()
        {
            var socketOptions = new PureWebSocketOptions()
            {
                DebugMode = true,
                SendDelay = 100
            };

            _ws = new PureWebSocket(_url, socketOptions);

            _ws.OnStateChanged += Ws_OnStateChanged;
            _ws.OnMessage += Ws_OnMessage;
            _ws.OnClosed += Ws_OnClosed;
            _ws.OnSendFailed += _ws_OnSendFailed;
            _ws.Connect();

            var timer = new Timer(OnTick, null, 1000, 500);

            Console.ReadLine();
        }

        private void _ws_OnSendFailed(string data, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now} Send Failed: {ex.Message}");
            Console.ResetColor();
            Console.WriteLine("");
        }

        private void OnTick(object state)
        {
            _ws.Send(DateTime.Now.Ticks.ToString());
        }

        private void Ws_OnClosed(WebSocketCloseStatus reason)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now} Connection Closed: {reason}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.ReadLine();
        }

        private void Ws_OnMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{DateTime.Now} New message: {message}");
            Console.ResetColor();
            Console.WriteLine("");
        }

        private void Ws_OnStateChanged(WebSocketState newState, WebSocketState prevState)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{DateTime.Now} Status changed from {prevState} to {newState}");
            Console.ResetColor();
            Console.WriteLine("");
        }
    }
}
