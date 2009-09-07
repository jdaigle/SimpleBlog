using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleBlog.Web.Models.Domain.Repositories.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace SimpleBlog.Web.Models.Domain.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ISession session)
            :base(session)
        {
        }

        public IQueryable<ProjectCategory> GetAllCategories()
        {
            return Session.Linq<ProjectCategory>();
        }

        public IQueryable<Project> GetAllProjectsByCategory(ProjectCategory category)
        {
            return Linq().Where(x => x.Category == category);
        }

        public ProjectImage GetImageById(int id)
        {
            return Session.Linq<ProjectImage>().Where(x => x.Id == id).FirstOrDefault();
        }

        public Project GetProjectById(int id)
        {
            return Linq().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
