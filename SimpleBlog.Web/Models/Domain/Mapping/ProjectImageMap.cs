using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace SimpleBlog.Web.Models.Domain.Mapping
{
    public class ProjectImageMap : ClassMap<ProjectImage>
    {
        public ProjectImageMap()
        {
            Table("ProjectImages");
            Id(x => x.Id)
                .GeneratedBy.Identity();
            References(x => x.Project)
                .Not.Nullable()
                .Column("ProjectId")
                .Cascade.None();
            Map(x => x.Thumbnail)
                .Not.Nullable()
                .LazyLoad();
            Map(x => x.FullSize)
                .Not.Nullable()
                .LazyLoad();
        }
    }
}