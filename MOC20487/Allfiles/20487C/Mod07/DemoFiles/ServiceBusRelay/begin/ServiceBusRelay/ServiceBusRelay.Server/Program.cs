using ServiceBusRelay.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ServiceBus;

namespace ServiceBusRelay.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //// For local TCP.
            //var host = new ServiceHost(typeof(ConsoleService),
            //    new Uri("net.tcp://127.0.0.1:747/"));
            //var endpoint = host.AddServiceEndpoint(typeof(IConsoleService),
            //    new NetTcpBinding(), "console");

            // For Azure Service Bus.
            var host = new ServiceHost(typeof(ConsoleService),
                new Uri("sb://ServiceBusDemo20487C07.servicebus.windows.net"));
            var endpoint = host.AddServiceEndpoint(typeof(IConsoleService),
                new NetTcpRelayBinding(), "console");

            endpoint.EndpointBehaviors.Add(new TransportClientEndpointBehavior
            {
                TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                    "RootManageSharedAccessKey",
                    "XTPk/KUGgmRA6dIL77J2OHve9mld4B6SRa4OJwanrxA=")
            });

            host.Open();

            Console.WriteLine("The server is running");
            Console.ReadKey();
            host.Close();
        }
    }
}
