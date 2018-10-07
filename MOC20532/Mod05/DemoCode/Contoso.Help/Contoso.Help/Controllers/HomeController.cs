using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Contoso.Help.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //return View();
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);  // 500
        }

        public ActionResult Contact()
        {
            Thread.Sleep(5000);
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}