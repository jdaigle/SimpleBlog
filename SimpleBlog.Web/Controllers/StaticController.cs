using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace SimpleBlog.Web.Controllers
{
    public partial class StaticController : Controller
    {
        public virtual RedirectToRouteResult Index()
        {
            return RedirectToAction(MVC.Projects.Index());
        }

        public virtual RedirectToRouteResult Projects()
        {
            return RedirectToAction(MVC.Projects.Index());
        }
    }
}
