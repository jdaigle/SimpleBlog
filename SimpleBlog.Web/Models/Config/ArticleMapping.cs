using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenEntity.Mapping;

namespace SimpleBlog.Web.Models.Config
{
    public class ArticleMapping : ClassConfiguration<Article>
    {
        public ArticleMapping()
        {
            ForTable("articles");
            Maps(x => x.Id);
            Maps(x => x.Title);
            Maps(x => x.Content);
            Maps(x => x.ShowOn);
        }
    }
}
