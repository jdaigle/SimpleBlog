using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OpenEntity.Mapping;

namespace SimpleBlog.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                string.Empty,
                "articles/list/{page}",
                new { controller = MVC.Articles.Name, action = MVC.Articles.Actions.List, page = 0 }
                );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = MVC.Articles.Name, action = MVC.Articles.Actions.Index, id = "" }
            );

        }

        public static void InitializeDataAccess()
        {
            MappingConfiguration.AddAssembly(typeof(MvcApplication).Assembly);
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            InitializeDataAccess();
        }
    }
}