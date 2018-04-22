using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.TestHost;
using SignalR_AspCore2Sample;
using Xunit;

namespace SignalRAspCore2Tests
{
    public class UnitTest1
    {

		[Fact]
        public async Task SignalRServerTest()
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder().UseStartup<Startup>();

            using (var testServer = new TestServer(webHostBuilder))
            {
                var hubConnection = await StartConnectionAsync(testServer.CreateHandler());
            }
        }

        private static async Task<HubConnection> StartConnectionAsync(HttpMessageHandler handler)
        {
            var hubConnection = new HubConnectionBuilder()
				.WithUrl($"http://localhost:5002/hubs")
				.WithMessageHandler((HttpMessageHandler arg) => handler)
                .WithConsoleLogger()
				.WithTransport(Microsoft.AspNetCore.Http.Connections.TransportType.LongPolling)
                .Build();
            
            await hubConnection.StartAsync();

            return hubConnection;
        }


		//[Fact]
   //     public void HubsAreMockableViaDynamic()
   //     {
   //         bool sendCalled = false;
   //         var hub = new ChatClass();
			//var mockClients = new Mock<IHubCallerClients<dynamic>>();
			//hub.Clients = mockClients.Object as IHubCallerClients;
        //    dynamic all = new ExpandoObject();
        //    all.broadcastMessage = new Action<string, string>((name, message) => {
        //        sendCalled = true;
        //    });
        //    mockClients.Setup(m => m.All).Returns((ExpandoObject)all);
        //    hub.Send("Hello Wolrd");

        //    Assert.True(sendCalled);
        //}
    }
}
