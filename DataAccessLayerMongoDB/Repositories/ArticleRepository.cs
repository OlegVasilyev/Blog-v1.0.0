using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Entities.Models;
using DataAccessLayerInterfaces.Interfaces;
using DataAccessLayerMongoDB.Context;
using MongoDB.Driver.Linq;
using System.Collections;

namespace DataAccessLayerMongoDB.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly BlogContext blogContext;
        public ArticleRepository(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public Article Get(int Id)
        {
            BsonDocument filter = new BsonDocument("Id", Id);
            return blogContext.Articles.Find<Article>(filter).First();
        }

        public void Create(Article item)
        {
            blogContext.Articles.InsertOne(item);
        }
        public void Delete(int Id)
        {
            blogContext.Articles.DeleteOne(Builders<Article>.Filter.Where(x => x.Id == Id));
        }
        public IEnumerable<Article> Find(Func<Article, bool> predicate)
        {
            return blogContext.Articles.Find<Article>(predicate.ToBsonDocument()).ToList();
        }
        public IEnumerable<Article> GetAll()
        {
            return blogContext.Articles.Find<Article>(new BsonDocument()).ToList();
        }
        public void Update(Article item)
        {
            blogContext.Articles.ReplaceOne(doc => doc.Id == item.Id, item);
        }
    }
}