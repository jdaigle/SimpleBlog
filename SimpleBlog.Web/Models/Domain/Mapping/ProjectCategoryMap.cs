using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace SimpleBlog.Web.Models.Domain.Mapping
{
    public class ProjectCategoryMap: ClassMap<ProjectCategory>
    {
        public ProjectCategoryMap()
        {
            Table("ProjectCategories");
            Id(x => x.Id)
                .GeneratedBy.Identity();
            Map(x => x.Name)
                .Not.Nullable()
                .Length(15);
        }
    }
}