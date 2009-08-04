using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SimpleBlog.Web.Models;
using SimpleBlog.Web.Models.Repositories;
using OpenEntity.DataProviders;

namespace SimpleBlog.Web.Controllers
{
    public partial class ArticlesController : Controller
    {
        private const int PAGE_SIZE = 3;
        private ArticleRepository articleRepostory;

        public ArticlesController()
        {
            var dataProvider = DataProviderFactory.CreateNewProvider("SimpleBlog");
            articleRepostory = new ArticleRepository(dataProvider);
        }

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Articles.List(0));
        }

        public virtual ActionResult List(int page)
        {
            var articles = articleRepostory.FetchPage(page, PAGE_SIZE);
            return View(articles);
        }

        public virtual ActionResult Details(int id)
        {
            var article = articleRepostory.FetchById(id);
            return View(article);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create(Article article)
        {
            try
            {
                articleRepostory.Save(article);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Exception", e);
                return View();
            }
        }

        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Edit(Article article)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
