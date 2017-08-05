using DataAccessLayerInterfaces.Interfaces;
using DataAccessLayerSQL.Context;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayerSQL.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly BlogContext context;
        public ArticleRepository(BlogContext context)
        {
            this.context = context;
        }
        public void Create(Article item)
        {
            context.Articles.Add(item);
        }

        public void Delete(int Id)
        {
            var article = context.Articles.Find(Id);
            if (article != null)
                context.Articles.Remove(article);
        }

        public IEnumerable<Article> Find(Func<Article, bool> predicate)
        {
            return context.Articles.Where(predicate).ToList();
        }

        public Article Get(int Id)
        {
            return context.Articles.Find(Id);
        }

        public IEnumerable<Article> GetAll()
        {
            return context.Articles;
        }

        public void Update(Article item)
        {
            var temp = context.Articles.Find(item.Id);
            if(temp != null)
            {
                context.Entry(temp).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}