using ServiceBusRelay.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

using Microsoft.ServiceBus;

namespace ServiceBusRelay.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Write(string text)
        {
            //// For local TCP.
            //var factory = new ChannelFactory<IConsoleService>(new NetTcpBinding(),
            //    new EndpointAddress("net.tcp://127.0.0.1:747/console"));

            // For Azure Service Bus.
            var factory = new ChannelFactory<IConsoleService>(new NetTcpRelayBinding(),
                new EndpointAddress("sb://ServiceBusDemo20487C07.servicebus.windows.net/console"));
            factory.Endpoint.EndpointBehaviors.Add(
                new TransportClientEndpointBehavior
                {
                    TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                        "RootManageSharedAccessKey",
                        "XTPk/KUGgmRA6dIL77J2OHve9mld4B6SRa4OJwanrxA=")
                }
                );

            var proxy = factory.CreateChannel();
            try
            {
                proxy.Write(text);
            }
            catch (Exception)
            {

                throw;
            }


            (proxy as IClientChannel).Close();
            return Redirect(Request.ApplicationPath);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
