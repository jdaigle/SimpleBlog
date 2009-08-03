﻿// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

#region T4MVC

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[CompilerGenerated]
public static class MVC {
    public static SimpleBlog.Web.Controllers.ArticlesController Articles = new T4MVC_ArticlesController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}


namespace SimpleBlog.Web.Controllers {
    public partial class ArticlesController {

        [CompilerGenerated]
        protected ArticlesController(_Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }

        [NonAction]
        public ActionResult List() {
            return new T4MVC_ActionResult(Name, Actions.List);
        }

        [NonAction]
        public ActionResult Details() {
            return new T4MVC_ActionResult(Name, Actions.Details);
        }

        [NonAction]
        public ActionResult Edit() {
            return new T4MVC_ActionResult(Name, Actions.Edit);
        }


        [CompilerGenerated]
        public readonly string Name = "Articles";

        static readonly _Actions s_actions = new _Actions();
        [CompilerGenerated]
        public _Actions Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class _Actions {
            public readonly string Index = "Index";
            public readonly string List = "List";
            public readonly string Details = "Details";
            public readonly string Create = "Create";
            public readonly string Edit = "Edit";
        }

        static readonly _Views s_views = new _Views();
        [CompilerGenerated]
        public _Views Views { get { return s_views; } }
        [CompilerGenerated]
        public class _Views {
            public readonly string Create = "Create";
            public readonly string Details = "Details";
            public readonly string List = "List";
        }
    }
}
namespace T4MVC {
    public class SharedController {


        static readonly _Views s_views = new _Views();
        [CompilerGenerated]
        public _Views Views { get { return s_views; } }
        [CompilerGenerated]
        public class _Views {
            public readonly string Error = "Error";
        }
    }
}

namespace T4MVC {
    [CompilerGenerated]
    public class T4MVC_ArticlesController: SimpleBlog.Web.Controllers.ArticlesController {
        public T4MVC_ArticlesController() : base(_Dummy.Instance) { }

        public override ActionResult Index() {
            var callInfo = new T4MVC_ActionResult("Articles", Actions.Index);
            return callInfo;
        }

        public override ActionResult List(int page) {
            var callInfo = new T4MVC_ActionResult("Articles", Actions.List);
            callInfo.RouteValues.Add("page", page);
            return callInfo;
        }

        public override ActionResult Details(int id) {
            var callInfo = new T4MVC_ActionResult("Articles", Actions.Details);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

        public override ActionResult Create() {
            var callInfo = new T4MVC_ActionResult("Articles", Actions.Create);
            return callInfo;
        }

        public override ActionResult Create(SimpleBlog.Web.Models.Article article) {
            var callInfo = new T4MVC_ActionResult("Articles", Actions.Create);
            callInfo.RouteValues.Add("article", article);
            return callInfo;
        }

        public override ActionResult Edit(int id) {
            var callInfo = new T4MVC_ActionResult("Articles", Actions.Edit);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

        public override ActionResult Edit(SimpleBlog.Web.Models.Article article) {
            var callInfo = new T4MVC_ActionResult("Articles", Actions.Edit);
            callInfo.RouteValues.Add("article", article);
            return callInfo;
        }

    }

    [CompilerGenerated]
    public class _Dummy {
        private _Dummy() { }
        public static _Dummy Instance = new _Dummy();
    }
}

namespace System.Web.Mvc {
    [CompilerGenerated]
    public static class T4Extensions {
        public static string ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result) {
            return htmlHelper.RouteLink(linkText, result.GetRouteValueDictionary());
        }

        public static string ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result, object htmlAttributes) {
            return ActionLink(htmlHelper, linkText, result, new RouteValueDictionary(htmlAttributes));
        }

        public static string ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result, IDictionary<string, object> htmlAttributes) {
            return htmlHelper.RouteLink(linkText, result.GetRouteValueDictionary(), htmlAttributes);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod) {
            return htmlHelper.BeginForm(result, formMethod, null);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod, object htmlAttributes) {
            return BeginForm(htmlHelper, result, formMethod, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod, IDictionary<string, object> htmlAttributes) {
            var callInfo = (IT4MVCActionResult)result;
            return htmlHelper.BeginForm(callInfo.Action, callInfo.Controller, callInfo.RouteValues, formMethod, htmlAttributes);
        }

        public static string Action(this UrlHelper urlHelper, ActionResult result) {
            return urlHelper.RouteUrl(result.GetRouteValueDictionary());
        }

        public static string ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions);
        }

        public static string ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions, object htmlAttributes) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions, new RouteValueDictionary(htmlAttributes));
        }

        public static string ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions, htmlAttributes);
        }

        public static Route MapRoute(this RouteCollection routes, string name, string url, ActionResult result) {
            return routes.MapRoute(name, url, result, (ActionResult)null);
        }

        public static Route MapRoute(this RouteCollection routes, string name, string url, ActionResult result, object defaults) {
            // Start by adding the default values from the anonymous object (if any)
            var routeValues = new RouteValueDictionary(defaults);

            // Then add the Controller/Action names and the parameters from the call
            foreach (var pair in result.GetRouteValueDictionary()) {
                routeValues.Add(pair.Key, pair.Value);
            }

            // Create and add the route
            var route = new Route(url, routeValues, new MvcRouteHandler());
            routes.Add(name, route);
            return route;
        }

        public static RouteValueDictionary GetRouteValueDictionary(this ActionResult result) {
            return ((IT4MVCActionResult)result).RouteValues;
        }

        public static void InitMVCT4Result(this IT4MVCActionResult result, string controller, string action) {
            result.Controller = controller;
            result.Action = action; ;
            result.RouteValues = new RouteValueDictionary();
            result.RouteValues.Add("Controller", controller);
            result.RouteValues.Add("Action", action);
        }
    }
}

[CompilerGenerated]
public interface IT4MVCActionResult {
    string Action { get; set; }
    string Controller { get; set; }
    RouteValueDictionary RouteValues { get; set; }
}

[CompilerGenerated]
public class T4MVC_ActionResult : ActionResult, IT4MVCActionResult {
    public T4MVC_ActionResult(string controller, string action): base()  {
        this.InitMVCT4Result(controller, action);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public RouteValueDictionary RouteValues { get; set; }
}


namespace Links {
    [CompilerGenerated]
    public static class @Scripts {
        public static string Url() { return VirtualPathUtility.ToAbsolute("~/Scripts"); }
        public static string Url(string fileName) { return VirtualPathUtility.ToAbsolute("~/Scripts/" + fileName); }
        public static readonly string jquery_1_3_2_vsdoc_js = Url("jquery-1.3.2-vsdoc.js");
        public static readonly string jquery_1_3_2_js = Url("jquery-1.3.2.js");
        public static readonly string jquery_1_3_2_min_vsdoc_js = Url("jquery-1.3.2.min-vsdoc.js");
        public static readonly string jquery_1_3_2_min_js = Url("jquery-1.3.2.min.js");
        public static readonly string MicrosoftAjax_debug_js = Url("MicrosoftAjax.debug.js");
        public static readonly string MicrosoftAjax_js = Url("MicrosoftAjax.js");
        public static readonly string MicrosoftMvcAjax_debug_js = Url("MicrosoftMvcAjax.debug.js");
        public static readonly string MicrosoftMvcAjax_js = Url("MicrosoftMvcAjax.js");
    }

    [CompilerGenerated]
    public static class @Content {
        public static string Url() { return VirtualPathUtility.ToAbsolute("~/Content"); }
        public static string Url(string fileName) { return VirtualPathUtility.ToAbsolute("~/Content/" + fileName); }
        public static readonly string Site_css = Url("Site.css");
    }

}

#endregion T4MVC

