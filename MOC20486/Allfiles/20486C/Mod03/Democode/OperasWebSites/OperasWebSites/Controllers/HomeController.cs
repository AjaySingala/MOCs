using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperasWebSites.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult TestView()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewData["AnotherMessage"] = "This is another message via ViewData";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search(string title)
        {
            ViewBag.Message = title;
            ViewBag.ServerTime = DateTime.Now;
            return View("About");

        }
    }
}