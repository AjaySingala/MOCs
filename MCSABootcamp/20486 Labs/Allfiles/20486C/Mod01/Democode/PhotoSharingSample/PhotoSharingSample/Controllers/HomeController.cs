using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApplication.Controllers
{
    public class HomeController : Controller
    {
        private PhotoSharingDB db = new PhotoSharingDB();

        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.SomeMessage = "This was just added.";
            return View();
        }

        public ActionResult PhotoList()
        {
            ViewBag.Sample = "<b>This is in bold</b>";
            var photos = db.Photos.ToList();
            return View(photos);
        }

        public ActionResult Details(int id = 0)
        {
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

    }
}
