using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate.Tool.hbm2ddl;
using Centro.NHibernateUtils;
using System.Reflection;
using SimpleBlog.Web.Models.Domain.Mapping;
using FluentNHibernate.Cfg.Db;

namespace SimpleBlog.Web.Tests
{
    [TestFixture]
    public class MSSqlSchemaTests
    {
        [Test, Explicit]
        public void GenerateSchema()
        {
            var mappingAssemblies = new List<Assembly> { typeof(ProjectMap).Assembly };
            var fluentConfiguration = new FluentConfigurationBuilder(MsSqlConfiguration.MsSql2005.ConnectionString(@"Server=.\SQLEXPRESS;Database=SimpleBlog;Trusted_Connection=yes;"), mappingAssemblies);
            new SchemaExport(fluentConfiguration.Configuration).Create(true, false);
        }
    }
}
