using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Web.Controllers
{
    [HandleError]
    public partial class HomeController : Controller
    {
        
        public virtual ActionResult Index()
        {           
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }
    }
}
