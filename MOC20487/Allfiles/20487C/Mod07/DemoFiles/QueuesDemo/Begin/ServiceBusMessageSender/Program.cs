using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.Configuration;

namespace ServiceBusMessageSender
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = CloudConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            string connectionString = 
                ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.QueueExists("servicebusqueue"))
            {
                namespaceManager.CreateQueue("servicebusqueue");
            }

            QueueClient queueClient = QueueClient.Create("servicebusqueue");

            Console.WriteLine("Enter text to send to the queue and press Enter.");
            string message = string.Empty;
            while ((message = Console.ReadLine()) != string.Empty)
            {
                // Create and Send Message to Queue
                var brokeredMessage = new BrokeredMessage(message);
                queueClient.Send(brokeredMessage);
            }
        }
    }
}
