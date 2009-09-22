using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Centro.MVC.Controllers;
using Centro.NHibernateUtils;
using NHibernate;
using SimpleBlog.Web.Controllers;
using SimpleBlog.Web.Models.Domain;
using StructureMap;
using StructureMap.Attributes;

namespace SimpleBlog.Web
{
    public class MVCConfiguration
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("Content/{*resource}");
            routes.IgnoreRoute("Scripts/{*resource}");
            routes.IgnoreRoute("Images/{*resource}");

            routes.MapRoute(
                string.Empty,
                "projects/list/{projectId}",
                new { controller = MVC.Projects.Name, action = MVC.Projects.Actions.List, projectId = 0 }
                );

            routes.MapRoute(
                string.Empty,
                "{controller}/{action}/{id}",
                new { controller = MVC.Static.Name, action = MVC.Static.Actions.Index, id = "" }
            );

        }

        public static void InitializeIoCAndDataAccess()
        {
            var mappingAssemblies = new List<Assembly> { typeof(SimpleBlog.Web.Models.Domain.Mapping.ProjectMap).Assembly };
#if SQLITE
            var nhibernateRegistry = SQLiteBuilder.CreateRegistry("SimpleBlog", mappingAssemblies, InstanceScope.HttpContext);
#else
            var nhibernateRegistry = MSSqlBuilder.CreateRegistry("SimpleBlog", mappingAssemblies, InstanceScope.HttpContext);
#endif
            ObjectFactory.Initialize(i =>
            {
                i.AddRegistry(nhibernateRegistry);

                i.Scan(s =>
                {
                    s.IncludeNamespaceContainingType<StaticController>();
                    s.AddAllTypesOf<IController>();
                });

                i.Scan(x =>
                {
                    x.AssemblyContainingType<SimpleBlog.Web.Models.Domain.Repositories.Interfaces.IProjectRepository>();
                    x.AssemblyContainingType<SimpleBlog.Web.Models.Domain.Repositories.ProjectRepository>();
                    x.With<StructureMap.Graph.DefaultConventionScanner>();
                });
            });

#if DEBUG
            ObjectFactory.AssertConfigurationIsValid();
#endif

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

#if SQLITE
            SQLiteUtil.GenerateSchema(nhibernateRegistry.Configuration, ObjectFactory.GetInstance<ISession>());
            SQLiteUtil.InitializeData(SQLiteTestData, ObjectFactory.GetInstance<ISession>());
            ObjectFactory.GetInstance<ISession>().Clear();
#endif

#if DEBUG
            //new SchemaExport(cfg).SetOutputFile("SimpleBlogSchema.sql").Create(false, false);
#endif
        }


        private static void SQLiteTestData()
        {
            var session = ObjectFactory.GetInstance<ISession>();

            // Project Categories
            var digitalWorksCategory = new ProjectCategory
            {
                Name = "Digital Works"
            };
            digitalWorksCategory = (ProjectCategory)session.SaveOrUpdateCopy(digitalWorksCategory);

            var craftsCategory = new ProjectCategory
            {
                Name = "Crafts"
            };
            craftsCategory = (ProjectCategory)session.SaveOrUpdateCopy(craftsCategory);

            // Projects

            var thumbnail1 = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(@"C:\Users\Public\Pictures\website_size_update\glassinitial_thumb_38.jpg");
            var thumbnail2 = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(@"C:\Users\Public\Pictures\website_size_update\glow_thumb_38.jpg");
            var fullsize1 = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(@"C:\Users\Public\Pictures\website_content\glassinitial_main.jpg");
            var fullsize2 = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(@"C:\Users\Public\Pictures\website_content\glow_main.jpg");


            for (int i = 0; i < 16; i++)
            {
                var thumbnail = new ProjectImage
                {
                    Data = thumbnail1,
                };
                var image = new ProjectImage
                {
                    Data = fullsize1,
                };
                var project = new Project
                {
                    Name = "Digital Works Project " + i,
                    Description = "This is my " + i + "th digital works project",
                    Category = digitalWorksCategory,
                    Thumbnail = thumbnail,
                    Image = image,
                };
                project = (Project)session.SaveOrUpdateCopy(project);
            }

            for (int i = 0; i < 10; i++)
            {
                var thumbnail = new ProjectImage
                {
                    Data = thumbnail2,
                };
                var image = new ProjectImage
                {
                    Data = fullsize2,
                };
                var project = new Project
                {
                    Name = "Crafts Project " + i,
                    Description = "This is my " + i + "th crafts project",
                    Category = craftsCategory,
                    Thumbnail = thumbnail,
                    Image = image,
                };
                project = (Project)session.SaveOrUpdateCopy(project);
            }
        }
    }
}
