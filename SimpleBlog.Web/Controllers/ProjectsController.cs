using System.Drawing.Imaging;
using System.Linq;
using System.Web.Mvc;
using SimpleBlog.Web.ActionFilters;
using SimpleBlog.Web.Models.Domain.Repositories.Interfaces;
using SimpleBlog.Web.Models.View;
using SimpleBlog.Web.Mvc;
using System.Web;
using SimpleBlog.Web.Models.Domain;

namespace SimpleBlog.Web.Controllers
{
    public partial class ProjectsController : Controller
    {
        private readonly IProjectRepository projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public virtual RedirectToRouteResult Index()
        {
            return RedirectToAction(MVC.Projects.List(0));
        }

        public virtual ViewResult List(int projectId)
        {
            var projectListing = new ProjectListing();

            var projectCategories = projectRepository.GetAllCategories();
            foreach (var category in projectCategories)
            {
                var projects = projectRepository.GetAllProjectsByCategory(category).ToList();
                projectListing.Add(category, projects);
                for (int i = 0; i < projects.Count; i++)
                {
                    if (projects[i].Id == projectId)
                    {
                        projectListing.SelectedProject = projects[i];
                        projectListing.BackId = i > 0 ? projects[i - 1].Id : projectId;
                        projectListing.NextId = i < projects.Count - 1 ? projects[i + 1].Id : projectId;
                        break;
                    }
                }
            }

            if (projectListing.SelectedProject == null)
            {
                projectListing.SelectedProject = projectListing.First().Value.FirstOrDefault();
                if (projectListing.SelectedProject != null)
                {
                    projectListing.BackId = projectListing.SelectedProject.Id;
                    projectListing.NextId = projectListing.First().Value.Count > 1 ? projectListing.First().Value[1].Id : projectListing.SelectedProject.Id;
                }
            }

            return View(projectListing);
        }

        public virtual ActionResult Image(int id)
        {
            var image = projectRepository.GetImageById(id);
            if (image.Data == null)
                return new EmptyResult();
            return new ImageResult
            {
                Image = image.Data,
                ImageFormat = ImageFormat.Png,
            };
        }

        [Authorize]
        public virtual ViewResult Admin()
        {
            var categories = projectRepository.GetAllCategories().ToList();
            return View(new AdminDto
            {
                AllCategories = categories,
            });
        }

        [Authorize]
        [RequireTransaction]
        public virtual RedirectToRouteResult AddCategory(string name)
        {
            projectRepository.CreateCategory(name);
            return RedirectToAction(MVC.Projects.Admin());
        }

        [Authorize]
        [RequireTransaction]
        public virtual RedirectToRouteResult DeleteCategory(int id)
        {
            projectRepository.DeleteCategoryById(id);
            return RedirectToAction(MVC.Projects.Admin());
        }

        [Authorize]
        public virtual ViewResult EditCategory(int id)
        {
            return View(projectRepository.GetCategoryById(id));
        }

        [Authorize]
        [RequireTransaction]
        public virtual RedirectToRouteResult RenameCategory(int id, string name)
        {
            projectRepository.RenameCategory(id, name);
            return RedirectToAction(MVC.Projects.Admin());
        }


        [Authorize]
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditProject(int id)
        {
            ViewData["Categories"] = projectRepository.GetAllCategories().ToList();
            return View(projectRepository.GetProjectById(id));
        }

        [Authorize]
        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public virtual RedirectToRouteResult EditProject(int id, string name, string description, int categoryId)
        {
            var project = projectRepository.GetProjectById(id);
            project.Name = name;
            project.Description = description;
            project.Category = projectRepository.GetCategoryById(categoryId);
            projectRepository.Save(ref project);
            return RedirectToAction(MVC.Projects.Admin());
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateProject()
        {
            ViewData["Categories"] = projectRepository.GetAllCategories().ToList();
            return View();
        }

        [Authorize]
        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public virtual RedirectToRouteResult CreateProject(string name, string description, int categoryId)
        {
            projectRepository.CreateProject(name, description, projectRepository.GetCategoryById(categoryId));
            return RedirectToAction(MVC.Projects.Admin());
        }

        [Authorize]
        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual RedirectToRouteResult ChangeProjectThumbnail(int id, HttpPostedFileBase image)
        {
            var project = projectRepository.GetProjectById(id);            
            if (image != null)
            {
                if (project.Thumbnail == null)
                    project.Thumbnail = new ProjectImage();
                project.Thumbnail.Data = new System.Drawing.Bitmap(image.InputStream);
                projectRepository.Save(ref project);
            }
            return RedirectToAction(MVC.Projects.EditProject(id));
        }

        [Authorize]
        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual RedirectToRouteResult ChangeProjectImage(int id, HttpPostedFileBase image)
        {
            var project = projectRepository.GetProjectById(id);
            if (image != null)
            {
                if (project.Image == null)
                    project.Image = new ProjectImage();
                project.Image.Data = new System.Drawing.Bitmap(image.InputStream);
                projectRepository.Save(ref project);
            }
            return RedirectToAction(MVC.Projects.EditProject(id));
        }
    }
}
