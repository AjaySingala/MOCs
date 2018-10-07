using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;
using System.Net.Http.Headers;

namespace AsynchronousActions.Web.Controllers
{
    public class CountriesController : ApiController
    {
        // GET api/countries
        // public IEnumerable<string> Get()
		public async Task<IEnumerable<string>> Get()
        {
            // var result = GetCountries();
			var result = await GetCountries();
            return result.Descendants("{http://www.worldbank.org}name").Select(x => x.Value);
        }
  
        //private XDocument GetCountries()
		private async Task<XDocument> GetCountries()
        {            
            // var client = (HttpWebRequest)WebRequest.Create("http://localhost:8371/api/countries");            
            // client.Accept = "application/xml";
            // WebResponse response = client.GetResponse();
            // var document = XDocument.Load(response.GetResponseStream());
			
			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
			var response = await client.GetAsync("http://localhost:8371/api/countries");
			var document = XDocument.Load(await response.Content.ReadAsStreamAsync());
			
			
            return document;
        }
    }
}
