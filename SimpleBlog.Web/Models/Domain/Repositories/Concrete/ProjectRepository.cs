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

        public ProjectCategory CreateCategory(string name)
        {
            var newCategory = new ProjectCategory
            {
                Name = name,
            };
            return (ProjectCategory)Session.SaveOrUpdateCopy(newCategory);
        }

        public void DeleteCategoryById(int id)
        {
            Session.Delete(GetCategoryById(id));
        }

        public ProjectCategory GetCategoryById(int id)
        {
            return Session.Linq<ProjectCategory>().Where(x => x.Id == id).FirstOrDefault();
        }

        public ProjectCategory RenameCategory(int id, string name)
        {
            var category = GetCategoryById(id);
            category.Name = name;
            return (ProjectCategory)Session.SaveOrUpdateCopy(category);
        }

        public Project CreateProject(string name, string description, ProjectCategory projectCategory)
        {
            var project = new Project
            {
                Name = name,
                Description = description,
                Category = projectCategory,
            };
            return (Project)Session.SaveOrUpdateCopy(project);
        }
    }
}
