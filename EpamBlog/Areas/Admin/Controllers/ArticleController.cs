using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Interfaces;
using EpamBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpamBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ArticleController : Controller
    {
        readonly IArticleService _blogService;
        public ArticleController(IArticleService service)
        {
            _blogService = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDTO, Article>();
            });
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<Article>>(_blogService.GetArticles()));
        }

        [HttpPost]
        public ActionResult Index(Article article)
        {
            var configView = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDTO, Article>();
            });
            var configDto = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDTO, Article>();
            });
            var mapper = configDto.CreateMapper();

            try
            {
                article.Date = DateTime.UtcNow;
                if (article.Tags != null && article.Tags.Count > 0)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    var tags = article.Tags.FirstOrDefault().Split(' ');
                    article.Tags.Clear();
                    foreach (var tag in tags)
                    {
                        if (tag.Trim() == string.Empty) continue;
                        article.Tags.Add(tag.Trim());
                    }
                }
                var articleDto = mapper.Map<ArticleDTO>(article);
                _blogService.CreateArticle(articleDto);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            mapper = configView.CreateMapper();
            var model = mapper.Map<IEnumerable<Article>>(_blogService.GetArticles());
            return PartialView("Partials/ArticleList", model);
        }

        [HttpPost]
        public ActionResult DeleteArticle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            try
            {
                _blogService.DeleteArticle(id);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ArticleDTO, Article>();
                });
                var mapper = config.CreateMapper();
                return PartialView("Partials/_ArticleList",
                    mapper.Map<IEnumerable<Article>>(_blogService.GetArticles()));
            }
            catch (ValidationException ex)
            {
                return PartialView("ErrorPartial", ex);
            }
        }
    }
}