using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Web.Models.Domain
{
    public class ProjectCategory
    {
        public ProjectCategory()
        {
            Projects = new List<Project>();
        }
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual IList<Project> Projects { get; set; }
    }
}
