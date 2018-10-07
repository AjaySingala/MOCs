using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OperasWebSites.Models;

namespace OperasWebSites.Repositories
{
    public class OperaRepository : IOperaRepository
    {
        OperasDbContext _db = new OperasDbContext();

        public Opera Get(int id)
        {
            var operaRecord = _db.Operas
                .Where(o => o.OperaID == id)
                .FirstOrDefault();
            return operaRecord;
        }

        public IList<Opera> GetAll()
        {
            var operas = _db.Operas.ToList();
            return operas;
        }
    }
}