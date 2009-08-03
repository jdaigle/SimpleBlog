using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenEntity.Mapping;

namespace SimpleBlog.Web.Models.Mappings
{
    public class ArticleMapping : ClassMapping<Article>
    {
        public ArticleMapping()
        {
            this.ForTable("articles");
            this.Map(x => x.Id);
            this.Map(x => x.Title);
            this.Map(x => x.Content);
            this.Map(x => x.ShowOn);
        }
    }
}
