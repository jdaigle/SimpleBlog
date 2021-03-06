﻿using System;
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
                .ForeignKey("FK_Project_ProjectCategory")
                .Cascade.None();
            References(x => x.Thumbnail)
                .Nullable()
                .Column("Thumbnail")
                .ForeignKey("FK_Project_ThumbnailImage")
                .Cascade.All();
            References(x => x.Image)
                .Nullable()
                .Column("Image")
                .ForeignKey("FK_Project_Image")
                .Cascade.All();
        }
    }
}