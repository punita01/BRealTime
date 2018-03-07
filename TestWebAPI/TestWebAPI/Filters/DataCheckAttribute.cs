using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWebAPI.Filters
{
    public class DataCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var val = filterContext.HttpContext.Request;
            if (filterContext.HttpContext.Request.QueryString["pPolarisId"] != null)
            {
              
            }
        }
    }
}