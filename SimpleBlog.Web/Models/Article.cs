using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenEntity.Model;

namespace SimpleBlog.Web.Models
{
    public class Article : IDomainObject
    {
        public virtual int Id { get { return default(int); } }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime ShowOn { get; set; }
    }
}
