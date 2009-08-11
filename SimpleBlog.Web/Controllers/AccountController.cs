using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace SimpleBlog.Web.Controllers
{
    public partial class AccountController : Controller
    {
        public virtual ActionResult LogOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult LogOn(string password, bool rememberMe, string returnUrl)
        {
            var userName = "admin";
            if (!ValidateLogOn(userName, password))
            {
                return View();
            }
            FormsAuthentication.SetAuthCookie(userName, rememberMe);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(MVC.Static.Index());
            }
        }

        public virtual ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(MVC.Static.Index());
        }

        private bool ValidateLogOn(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "You must specify a password.");
            }
            if (!FormsAuthentication.Authenticate(userName, password))
            {
                ModelState.AddModelError("_FORM", "The password provided is incorrect.");
            }
            return ModelState.IsValid;
        }
    }
}
