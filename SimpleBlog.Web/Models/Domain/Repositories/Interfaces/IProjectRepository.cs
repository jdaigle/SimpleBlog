using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Web.Models.Domain.Repositories.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IQueryable<ProjectCategory> GetAllCategories();
        IQueryable<Project> GetAllProjectsByCategory(ProjectCategory category);
        ProjectImage GetImageById(int id);
        Project GetProjectById(int id);

        ProjectCategory CreateCategory(string name);

        void DeleteCategoryById(int id);

        ProjectCategory GetCategoryById(int id);

        ProjectCategory RenameCategory(int id, string name);

        Project CreateProject(string name, string description, ProjectCategory projectCategory);
    }
}
