using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;

namespace Wcf.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallServiceRef();
            //CallDoWork();
            CallWebRequest();
        }

        private static void CallDoWork()
        {
            var uri = "http://localhost:63872/CustomerService.svc/DoWork";
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            request.ContentLength = 0;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();

            Console.WriteLine(text);
        }

        private static void CallWebRequest()
        {
            var uri = "http://localhost:63872/CustomerService.svc/Get?id=101";
            string parameters = "{\"id\":\"101\"}";

            byte[] data = Encoding.UTF8.GetBytes(parameters);

            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            //request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = data.Length;
            //request.ContentLength = 0;

            //using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            //{
            //    writer.Write(parameters); 
            //}

            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.ContentLength == 0)
            {
                throw new NullReferenceException("Data not found");
            }

            var resultStream = new StreamReader(response.GetResponseStream());
            var result = resultStream.ReadToEnd();
            resultStream.Close();

            Console.WriteLine(result);
        }

        private static void CallServiceRef()
        {
            CustomerServiceReference.CustomerServiceClient client = new CustomerServiceReference.CustomerServiceClient();
            var result = client.Get(100);
            Console.WriteLine(result);
        }
    }
}
