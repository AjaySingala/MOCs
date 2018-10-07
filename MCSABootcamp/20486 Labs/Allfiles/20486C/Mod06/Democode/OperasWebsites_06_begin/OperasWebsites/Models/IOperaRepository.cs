using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperasWebsites.Models
{
    public interface IOperaRepository
    {
        Opera Get(int id);
    }
}