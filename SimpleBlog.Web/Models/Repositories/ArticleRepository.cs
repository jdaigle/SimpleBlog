using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenEntity.Repository;
using OpenEntity.DataProviders;
using OpenEntity.Query;
using System.Data;

namespace SimpleBlog.Web.Models.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>
    {
        public ArticleRepository(IDataProvider dataProvider)
            :base(dataProvider)
        {
        }

        public Article FetchById(int id)
        {
            var predicate = new PredicateExpression().Where<Article>(a => a.Id).IsEqualTo(id);
            return this.Fetch(predicate);
        }

        public IList<Article> FetchPage(int page, int pageSize)
        {
            var predicate = new PredicateExpression();
                            //.Where<Article>(a => a.Deleted).IsEqualTo(0)
            var orderClause = new OrderClause<Article>(a => a.ShowOn).Descending();
            var totalToFetch = (page * pageSize) + pageSize;
            var articles = this.FetchAll(predicate, null, orderClause, totalToFetch);
            return articles.OrderByDescending(a => a.ShowOn).Skip(page * pageSize).ToList();
        }
    }
}
