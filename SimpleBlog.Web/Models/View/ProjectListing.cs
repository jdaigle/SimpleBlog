using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleBlog.Web.Models.Domain;

namespace SimpleBlog.Web.Models.View
{
    public class ProjectListing : Dictionary<ProjectCategory, IList<Project>>
    {
        public int BackId { get; set; }
        public int NextId { get; set; }
        public Project SelectedProject { get; set; }
    }
}
