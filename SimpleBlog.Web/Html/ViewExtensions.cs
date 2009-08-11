using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;

namespace SimpleBlog.Web.Html
{
    public static class ViewExtensions
    {
        public static void RenderAction(this HtmlHelper helper, ActionResult result)
        {
            helper.RenderAction((string)result.GetRouteValueDictionary()["action"], (string)result.GetRouteValueDictionary()["controller"], result.GetRouteValueDictionary());
        }
    }
}
