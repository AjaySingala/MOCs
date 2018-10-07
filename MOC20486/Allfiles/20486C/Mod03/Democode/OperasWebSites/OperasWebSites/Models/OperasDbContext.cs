using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperasWebSites.Models
{
    public class OperasDbContext // : DbContext
    {
        public IList<Opera> Operas { get; set; }
        public IList<Comment> Comments { get; set; }

        public OperasDbContext()
        {
            Operas = new List<Opera>();
            Comments = new List<Comment>();
        }
    }
}