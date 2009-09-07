using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;

namespace SimpleBlog.Web.Models.Domain.Repositories
{
    public abstract class RepositoryBase<TEntityType> : IRepository<TEntityType>
    {
        protected readonly ISession Session;

        protected RepositoryBase(ISession session)
        {
            Session = session;
        }

        public void Save(ref TEntityType entity)
        {
            entity = (TEntityType)Session.SaveOrUpdateCopy(entity);
        }

        public IQueryable<TEntityType> Linq()
        {
            return Session.Linq<TEntityType>();
        }
    }
}
