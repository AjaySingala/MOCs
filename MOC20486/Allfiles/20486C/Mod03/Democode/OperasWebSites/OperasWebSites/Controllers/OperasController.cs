using OperasWebSites.Models;
using OperasWebSites.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperasWebSites.Controllers
{

    public class SimpleActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("This Event Fired: OnActionExecuting");
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("This Event Fired: OnActionExecuted");
        }
    }

    public class OperasController : Controller
    {
        IOperaRepository _repo;

        public OperasController()
        {
            _repo = new OperaRepository();
        }

        public OperasController(IOperaRepository repository)
        {
            _repo = repository;
        }

        // GET: Photos
        [SimpleActionFilter]
        public ActionResult Index()
        {
            var operas = _repo.GetAll();
            return View("Index");
        }

        // GET: Photos/Details/5
        public ActionResult Details(int id)
        {
            var operaRecord = _repo.Get(id);
            
            ViewBag.ForComment = "This text for comment view";

            var opera = new Opera()
            {
                OperaID = 101,
                Title = "Title",
                Year = 1945,
                Composer = "Mozart",
                Comments = new List<Comment>()
                {
                    new Comment { CommentId = 101, Subject = "CommentSubject1", CommentText = "Comment #1"},
                    new Comment { CommentId = 102, Subject = "CommentSubject2", CommentText = "Comment #2"},
                    new Comment { CommentId = 103, Subject = "CommentSubject3", CommentText = "Comment #3"}
                }
            };

            return View("Details", opera);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(Opera opera)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Create");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Photos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Photos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
