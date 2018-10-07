using OperaWebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSites.Controllers
{
    public class OperaController : Controller
    {
        // GET: Opera
        public ActionResult Index()
        {
            var operas = new List<Opera>()
            {
                new Opera {
                    OperaID = 101,
                    Title = "Opera #1",
                    Composer = "Yanni",
                    Year = 1999
                },
                new Opera {
                    OperaID = 102,
                    Title = "Opera #2",
                    Composer = "Mozart",
                    Year = 1954
                },
                new Opera {
                    OperaID = 103,
                    Title = "Opera #3",
                    Composer = "Beethoven",
                    Year = 1947
                }

            };

            return View("Index", operas);
        }

        public ActionResult Details(int id)
        {
            var opera = new Opera()
            {
                OperaID = 101,
                Title = "Opera #1",
                Composer = "Yanni",
                Year = 1999,
                Price = 2
            };

            //return View(opera);
            return View("Details", opera);
        }

        public string GetImage(int id)
        {
            // connect to db
            // fetch an image
            // convert to byte[]
            //return

            return "From GetData()";
        }

        public ActionResult Create()
        {
            var opera = new Opera();
            return View("Create", opera);
        }

        [HttpPost]
        public ActionResult Create(Opera newOpera)
        {
            if(ModelState.IsValid)
            {
                // Add record to the db.
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", newOpera);
            }
        }
    }
}