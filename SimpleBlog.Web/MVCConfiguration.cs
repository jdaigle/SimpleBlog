﻿using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Centro.MVC.Controllers;
using NHibernate.Tool.hbm2ddl;
using SimpleBlog.Web.Controllers;
using StructureMap;
using StructureMap.Attributes;
using NHibernate.Dialect;
using System.Data.SqlClient;
using System.IO;
using NHibernate;
using NHibernate.Linq;
using Centro.NHibernateUtils;
using SimpleBlog.Web.Models.Domain;
using System.Linq;

namespace SimpleBlog.Web
{
    public class MVCConfiguration
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
                string.Empty,
                "projects/list/{projectId}",
                new { controller = MVC.Projects.Name, action = MVC.Projects.Actions.List, projectId = 0 }
                );

            routes.MapRoute(
                string.Empty,
                "{controller}/{action}/{id}",
                new { controller = MVC.Projects.Name, action = MVC.Projects.Actions.Index, id = "" }
            );

        }

        public static void InitializeIoCAndDataAccess()
        {
            var mappingAssemblies = new List<Assembly> { typeof(SimpleBlog.Web.Models.Domain.Mapping.ProjectMap).Assembly };

            NHibernate.Cfg.Configuration cfg = null;

            ObjectFactory.Initialize(i =>
            {
#if SQLITE
                cfg = Centro.NHibernateUtils.Configuration.SetupSQLiteDataAccess(i, InstanceScope.HttpContext, mappingAssemblies, "SimpleBlog");
#else
                cfg = Centro.NHibernateUtils.Configuration.ConfigureMsSqlDataAccess(i, InstanceScope.HttpContext, mappingAssemblies, "SimpleBlog");
#endif

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
            SQLiteUtil.GenerateSchema(cfg, ObjectFactory.GetInstance<ISession>());
            SQLiteUtil.InitializeData(SQLiteTestData, ObjectFactory.GetInstance<ISession>());
            ObjectFactory.GetInstance<ISession>().Clear();
#endif

#if DEBUG
            new SchemaExport(cfg).SetOutputFile("SimpleBlogSchema.sql").Create(false, false);
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

            var thumbnail1 = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(@"C:\Users\Public\Pictures\website_content\glassinitial_thumb.jpg");
            var thumbnail2 = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(@"C:\Users\Public\Pictures\website_content\glow_thumb.jpg");
            var fullsize1 = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(@"C:\Users\Public\Pictures\website_content\glassinitial_main.jpg");
            var fullsize2 = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(@"C:\Users\Public\Pictures\website_content\glow_main.jpg");


            for (int i = 0; i < 16; i++)
            {
                var project = new Project
                {
                    Name = "Digital Works Project "+ i,
                    Description = "This is my " +i+"th digital works project",
                    Category = digitalWorksCategory,
                };
                project = (Project)session.SaveOrUpdateCopy(project);
                var image = new ProjectImage
                {
                    Project = project,
                    Thumbnail = thumbnail1,
                    FullSize = fullsize1,
                };
                session.SaveOrUpdateCopy(image);
            }

            for (int i = 0; i < 10; i++)
            {
                var project = new Project
                {
                    Name = "Crafts Project " + i,
                    Description = "This is my " + i + "th crafts project",
                    Category = craftsCategory,
                };
                project = (Project)session.SaveOrUpdateCopy(project);
                var image = new ProjectImage
                {
                    Project = project,
                    Thumbnail = thumbnail2,
                    FullSize = fullsize2,
                };
                session.SaveOrUpdateCopy(image);
            }
        }
    }
}