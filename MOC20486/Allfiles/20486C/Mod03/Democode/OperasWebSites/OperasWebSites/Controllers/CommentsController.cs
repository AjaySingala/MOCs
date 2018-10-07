using OperasWebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperasWebSites.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult _CommentsForArticle()
        {
            var commentsForArticle = new List<Comment>()
                {
                    new Comment { CommentId = 111, Subject = "ArticleComment1", CommentText = "Comment #1 for an Article"},
                    new Comment { CommentId = 112, Subject = "ArticleComment2", CommentText = "Comment #2 for an Article"},
                    new Comment { CommentId = 113, Subject = "ArticleComment3", CommentText = "Comment #3 for an Article"}
                };
            return PartialView("_CommentsList", commentsForArticle);
        }
    }
}