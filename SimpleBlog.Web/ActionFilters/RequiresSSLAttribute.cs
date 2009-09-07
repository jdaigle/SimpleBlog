using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Web.ActionFilters
{
    public class RequiresSSLAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var response = filterContext.HttpContext.Response;

            if (!request.IsSecureConnection && !request.IsLocal)
            {
                string url = request.Url.ToString().ToLower().Replace("http:", "https:");
                response.Redirect(url);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
