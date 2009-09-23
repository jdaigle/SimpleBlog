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
            Map(x => x.Data)
                .Not.Nullable()
                .Length(20000)
                .LazyLoad();
        }
    }
}