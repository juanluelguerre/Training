//
// https://github.com/Beffyman/SocketIo.Core
//
using SocketIo;
using SocketIo.SocketTypes;
using System;

namespace SignalRConsole
{
    public class SocketIOManager
    {
        private string _url;
        public SocketIOManager(string url)
        {
            _url = url;
        }

        public void Run()
        {
            var socket = Io.Create("127.0.0.1", 3000, 52421, SocketHandlerType.Udp);

            socket.On("connect", () =>
            {
                Console.WriteLine("Connected !");
                socket.On("login", (string user) =>
                {
                    Console.WriteLine("Logged !");
                }); 
                socket.Emit("login", new { name = "juanlu", password = "123456" } );
            });

            socket.Emit("connect");


            Console.WriteLine("Waiting for connection...");
            Console.WriteLine("Pulse INTRO para finalizar...");
            Console.ReadLine();


            socket.Close();

        }

    }
}
