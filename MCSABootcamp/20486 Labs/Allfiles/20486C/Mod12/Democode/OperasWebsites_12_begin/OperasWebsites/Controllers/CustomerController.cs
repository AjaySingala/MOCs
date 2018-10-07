using OperasWebsites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OperasWebsites.Controllers
{
    public class CustomerController : ApiController
    {
        private OperasDB contextDB = new OperasDB();

        // GET: /customer
        [HttpGet]
        public List<Opera> Get()
        {
            var operas = contextDB.Operas.ToList();
            return operas;
        }

        [HttpGet]
        // GET: /customer/5
        public Opera Get(int id)
        {
            var opera = contextDB.Operas.Find(id);
            return opera;
        }

        // POST: /customer
        [HttpPost]
        public void PostCustomer(Opera opera)
        {
            // add a new record.
            return;
        }

        // PUT: /customer/5
        [HttpPut]
        public void PutCustomer(int id, Opera opera)
        {
            // Find the record from the DB
            // Update it!
            return;
        }

        // DELETE: /customer/10
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            // Find the record from the DB
            // Delete it!
            return;
        }
    }
}
