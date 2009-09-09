using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleBlog.Web.Models.Domain;

namespace SimpleBlog.Web.Models.View
{
    public class AdminDto
    {
        public IList<ProjectCategory> AllCategories { get; set; }
    }
}
