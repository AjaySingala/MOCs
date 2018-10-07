using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using OperasWebsites.Models;

namespace OperasWebsites.Controllers
{
    public class OperasApiController : ApiController
    {
        private OperasDB contextDB = new OperasDB();

        public IEnumerable<Opera> GetOperas()
        {
            var operas = contextDB.Operas.ToList();
            return operas;
        }

        public Opera GetOperas(int id)
        {
            var opera = contextDB.Operas.Find(id);
            return opera;
        }
    }
}
