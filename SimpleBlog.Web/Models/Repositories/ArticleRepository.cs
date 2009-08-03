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
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(IDataProvider dataProvider)
            :base(dataProvider)
        {
        }

        public Article FetchById(int id)
        {
            var predicate = new PredicateExpression();
            predicate.AddWithAnd(new Constraint<Article>(a => a.Id).IsEqualTo(id));
            return this.Fetch(predicate);
        }

        public IList<Article> FetchPage(int page, int pageSize)
        {
            var predicate = new PredicateExpression();
            //predicate.AddWithAnd(new Constraint<Article>(a => a.Deleted).IsEqualTo(0));
            predicate.AddWithAnd(new ColumnConstraint(this.TableName, "deleted").IsEqualTo(0));
            var totalToFetch = (page * pageSize) + pageSize;
            var articles = this.FetchAll(predicate, null, totalToFetch);
            return articles.Skip(page * pageSize).ToList();
        }
    }
}
