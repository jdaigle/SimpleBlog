using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace SimpleBlog.Web.Models.Domain
{
    public class ProjectImage
    {
        public virtual int Id { get; private set; }
        public virtual Project Project { get; set; }
        public virtual Bitmap Thumbnail { get; set; }
        public virtual Bitmap FullSize { get; set; }
    }
}
