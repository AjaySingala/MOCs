using OperasWebsites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaWebSitesTests
{
    public class TestOperaRepository : IOperaRepository
    {
        public Opera Get(int id)
        {
            if (id == 0)
                return null;

            var opera = new Opera()
            {
                OperaID = 201,
                Composer = "ABC",
                Title = "XYZ",
                Year = 1987
            };

            return opera;
        }
    }
}
