using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Web.Models.Domain
{
    public class Project
    {
        public Project()
        {
            Images = new List<ProjectImage>();
        }
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ProjectCategory Category { get; set; }
        public virtual IList<ProjectImage> Images { get; set; }
    }
}
