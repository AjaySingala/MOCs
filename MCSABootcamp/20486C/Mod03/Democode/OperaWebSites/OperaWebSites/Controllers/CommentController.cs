using OperaWebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSites.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public PartialViewResult _CommentsForOpera(int id)
        {
            var comments = new List<Comment>()
            {
                new Comment { CommentId = 1, UserComment = "Comment #1" },
                new Comment { CommentId = 2, UserComment = "Comment #2" },
                new Comment { CommentId = 3, UserComment = "Comment #3" },
                new Comment { CommentId = 4, UserComment = "Comment #4" }
            };


            ViewBag.Message = "This is a ViewBag Message";

            return PartialView("_Comments", comments);
        }
    }
}