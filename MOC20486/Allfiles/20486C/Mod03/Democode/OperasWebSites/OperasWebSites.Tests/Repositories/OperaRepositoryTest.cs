using OperasWebSites.Models;
using OperasWebSites.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperasWebSites.Tests.Repositories
{
    public class OperaRepositoryTest : IOperaRepository
    {
        public Opera Get(int id)
        {
            var opera = new Opera
            {
                OperaID = 101,
                Title = "Some Title",
                Year = 1940,
                Composer = "Someone"
            };

            return opera;
        }

        public IList<Opera> GetAll()
        {
            var operas = new List<Opera>
            {
                new Opera
                {
                    OperaID = 101,
                    Title = "Some Title",
                    Year = 1940,
                    Composer = "Someone"
                },
                new Opera
                {
                    OperaID = 102,
                    Title = "Second Title",
                    Year = 1945,
                    Composer = "Another Composer"
                },
                new Opera
                {
                    OperaID = 103,
                    Title = "Third Title",
                    Year = 1964,
                    Composer = "Third Composer"
                }
            };

            return operas;
        }
    }
}
