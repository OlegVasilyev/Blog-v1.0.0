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
    public class QuizRepository : IRepository<Quiz>
    {
        private readonly BlogContext blogContext;
        public QuizRepository(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public Quiz Get(int Id)
        {
            BsonDocument filter = new BsonDocument("Id", Id);
            return blogContext.Quizes.Find<Quiz>(filter).First();
        }

        public void Create(Quiz item)
        {
            blogContext.Quizes.InsertOne(item);
        }
        public void Delete(int Id)
        {
            blogContext.Quizes.DeleteOne(Builders<Quiz>.Filter.Where(x => x.Id == Id));
        }
        public IEnumerable<Quiz> Find(Func<Quiz, bool> predicate)
        {
            return blogContext.Quizes.Find<Quiz>(predicate.ToBsonDocument()).ToList();
        }
        public IEnumerable<Quiz> GetAll()
        {
            return blogContext.Quizes.Find<Quiz>(new BsonDocument()).ToList();
        }
        public void Update(Quiz item)
        {
            blogContext.Quizes.ReplaceOne(doc => doc.Id == item.Id, item);
        }
    }
}