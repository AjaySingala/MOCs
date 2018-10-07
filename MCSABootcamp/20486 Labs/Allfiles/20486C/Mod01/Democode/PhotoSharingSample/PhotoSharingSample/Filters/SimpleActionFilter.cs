using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;


namespace PhotoSharingApplication.Filters
{
    public class SimpleActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext actionContext)
        {
            Debug.WriteLine("This Event Fired: OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            Debug.WriteLine("This Event Fired: OnActionExecuted");
        }
    }

    public class ResultActionFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext actionContext)
        {
            Debug.WriteLine("This Event Fired: OnResultExecuting");
        }

        public void OnResultExecuted(ResultExecutedContext actionExecutedContext)
        {
            Debug.WriteLine("This Event Fired: OnResultExecuted");
        }
    }
}