using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace SimpleBlog.Web.Models.Domain.Mapping
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Table("Projects");
            Id(x => x.Id)
                .GeneratedBy.Identity();
            Map(x => x.Name)
                .Not.Nullable()
                .Length(25);
            Map(x => x.Description)
                .Not.Nullable()
                .Length(255);
            References(x => x.Category)
                .Not.Nullable()
                .Column("CategoryId")
                .Cascade.None();
            HasMany(x => x.Images)
                .KeyColumn("ProjectId")
                .LazyLoad()
                .Inverse()
                .Cascade.All();
        }
    }
}