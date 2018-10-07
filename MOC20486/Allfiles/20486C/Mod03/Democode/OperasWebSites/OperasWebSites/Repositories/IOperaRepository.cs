using OperasWebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperasWebSites.Repositories
{
    public interface IOperaRepository
    {
        IList<Opera> GetAll();
        Opera Get(int id);
    }
}