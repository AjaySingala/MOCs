using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperasWebSites.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Subject { get; set; }
        public string CommentText { get; set; }

    }
}