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
        public virtual ActionResult Index()
        {
            return Redirect("/index.html");
        }

        public virtual ActionResult Projects()
        {
            return Redirect("/index.html");
        }
    }
}
