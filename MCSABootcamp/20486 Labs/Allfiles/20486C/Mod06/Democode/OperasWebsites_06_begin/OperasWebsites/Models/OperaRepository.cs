using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperasWebsites.Models
{
    public class OperaRepository : IOperaRepository
    {
        OperasDB _db = new OperasDB();

        public Opera Get(int id)
        {
            var opera = _db.Operas.Find(id);
            return opera;
        }
    }
}