using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.Interfaces;
using AutoMapper;
using EpamBlog.Models;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.DataTransferObjects;
using EpamBlog.ViewModels;

namespace EpamBlog.Controllers
{
    public class HomeController : Controller
    {
        IArticleService _articleService;
        public HomeController(IArticleService service)
        {
            this._articleService = service;
        }
       [HttpGet]
       public ActionResult Index()
        {
            var config = new MapperConfiguration(cfn =>
            {
                cfn.CreateMap<ArticleDTO, Article>();
            });
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<Article>>(_articleService.GetArticles()));
        }
        [HttpGet]
        public ActionResult DisplayArticle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            try
            {
                var article = _articleService.GetArticle(id);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ArticleDTO, Article>();
                });
                var mapper = config.CreateMapper();
                foreach (var item in article.Tags)
                {
                    Console.WriteLine(item);
                }
                return View(mapper.Map<Article>(article));
            }
            catch (ValidationException ex)
            {
                return View("Error", ex);
            }

        }

        [HttpGet]
        public ActionResult Search(string tag)
        {
            if (tag == null)
            {
                tag = "";
            }
            try
            {
                var articles = _articleService.GetArticles(tag);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ArticleDTO, Article>();
                });
                var mapper = config.CreateMapper();
                var articlesView = mapper.Map<IEnumerable<Article>>(articles);
                return View(new SearchByTag { Articles = articlesView.ToList(), TagText = tag });
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }
    }
}