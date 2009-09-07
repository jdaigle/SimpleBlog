using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Web.Models.Domain.Repositories
{
    public interface IRepository<TEntityType>
    {
        void Save(ref TEntityType entity);
        IQueryable<TEntityType> Linq();
    }
}
