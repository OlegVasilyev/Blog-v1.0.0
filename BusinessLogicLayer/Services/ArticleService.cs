using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DataTransferObjects;
using DataAccessLayerInterfaces.Interfaces;
using BusinessLogicLayer.Infrastructure;
using AutoMapper;
using Entities.Models;

namespace BusinessLogicLayer.Service
{
    public class ArticleService : IArticleService
    {
        IBlogRepository DataBase { get; }
        public ArticleService(IBlogRepository database)
        {
            this.DataBase = database;
        }

        public void CreateArticle(ArticleDTO articleDto)
        {
            ValidatorBlogModels.ValidateArticleModel(articleDto);
            Mapper.Initialize(config =>
            {
                config.CreateMap<ArticleDTO, Article>().ForMember(t => t.Tags, i => i.Ignore());
            });
            var articl = Mapper.Map<Article>(articleDto);
            var tags = DataBase.Tags.GetAll().ToList();
            foreach (var tag in articleDto.Tags)
            {
                var newTag = new Tagg() { Text = tag };
                if (tags.Find(x => x.Text.Equals(newTag.Text)) != null)
                {
                    articl.Tags.Add(tags.First(x => x.Text.Equals(newTag.Text)));
                }
                else
                {
                    DataBase.Tags.Create(newTag);
                    articl.Tags.Add(newTag);
                }
            }
            DataBase.Articles.Create(articl);
            DataBase.Save();
        }

        public void DeleteArticle(int? Id)
        {

            if (Id == null)
                throw new ValidationException("Id is null", "");
            if (!DataBase.Articles.Find(x => x.Id == Id).Any())
                throw new ValidationException("Article wasn't found", "");

            DataBase.Articles.Delete((int)Id);
            DataBase.Save();
        }

        public ArticleDTO GetArticle(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Article's id wasn't set", "");
            var article = DataBase.Articles.Get(Id.Value);
            if (article == null)
                throw new ValidationException("Article wasn't found", "");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDTO>().ForMember(a => a.Tags, o => o.Ignore());
            });
            var mapper = config.CreateMapper();
            var articleDto = mapper.Map<Article, ArticleDTO>(article);
            foreach (var tag in article.Tags)
            {
                articleDto.Tags.Add(tag.Text);
            }
            return articleDto;
        }

        public IEnumerable<ArticleDTO> GetArticles()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDTO>().ForMember(a => a.Tags, o => o.Ignore());
            });
            var mapper = config.CreateMapper();
            var articles = DataBase.Articles.GetAll().ToList();
            var articlesDto = mapper.Map<IEnumerable<ArticleDTO>>(DataBase.Articles.GetAll()).ToList();
            for (int i = 0; i < articles.Count(); i++)
            {
                foreach (var tag in articles[i].Tags)
                {
                    articlesDto[i].Tags.Add(tag.Text);
                }
            }

            return articlesDto;
        }

        public IEnumerable<ArticleDTO> GetArticles(string tag)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDTO>().ForMember(a => a.Tags, o => o.Ignore());
            });
            var mapper = config.CreateMapper();

            var tagNew = DataBase.Tags.Find(x => x.Text.Equals(tag)).FirstOrDefault();

            if (tagNew == null)
                return new List<ArticleDTO>();

            var articlesDto = mapper.Map<IEnumerable<ArticleDTO>>(tagNew.Articles.ToList()).ToList();
            for (int i = 0; i < tagNew.Articles.ToList().Count(); i++)
            {
                foreach (var innerTag in tagNew.Articles.ToList()[i].Tags)
                {
                    articlesDto[i].Tags.Add(innerTag.Text);
                }
            }
            return articlesDto;
        }
    }
}
