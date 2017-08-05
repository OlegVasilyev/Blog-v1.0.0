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
    public class AnswerRepository : IRepository<Answer>
    {
        private readonly BlogContext blogContext;
        public AnswerRepository(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public Answer Get(int Id)
        {
            BsonDocument filter = new BsonDocument("Id", Id);
            return blogContext.Answers.Find<Answer>(filter).First();
        }

        public void Create(Answer item)
        {
            blogContext.Answers.InsertOne(item);
        }
        public void Delete(int Id)
        {
           blogContext.Answers.DeleteOne(Builders<Answer>.Filter.Where(x => x.Id == Id));
        }
        public IEnumerable<Answer> Find(Func<Answer, bool> predicate)
        {
           return blogContext.Answers.Find<Answer>(predicate.ToBsonDocument()).ToList();
        }
        public IEnumerable<Answer> GetAll()
        {
            return blogContext.Answers.Find<Answer>(new BsonDocument()).ToList();
        }
        public void Update(Answer item)
        {
            blogContext.Answers.ReplaceOne(doc => doc.Id == item.Id, item);
        }
    }
}