using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //[ActionName("List")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            //return $"Success! {value}";

            var response = Request.CreateResponse(HttpStatusCode.Created, value);
            response.Headers.Location = new Uri(Request.RequestUri, value);

            return response;

        }

        // PUT api/values/5
        public string Put(int id, [FromBody]string value)
        {
            return $"Success! {value}";
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            return $"Success! {id}";

        }
    }
}
