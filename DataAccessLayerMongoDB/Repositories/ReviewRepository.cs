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
    public class ReviewRepository : IRepository<Review>
    {
        private readonly BlogContext blogContext;
        public ReviewRepository(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public Review Get(int Id)
        {
            BsonDocument filter = new BsonDocument("Id", Id);
            return blogContext.Reviews.Find<Review>(filter).First();
        }

        public void Create(Review item)
        {
            blogContext.Reviews.InsertOne(item);
        }
        public void Delete(int Id)
        {
            blogContext.Reviews.DeleteOne(Builders<Review>.Filter.Where(x => x.Id == Id));
        }
        public IEnumerable<Review> Find(Func<Review, bool> predicate)
        {
            return blogContext.Reviews.Find<Review>(predicate.ToBsonDocument()).ToList();
        }
        public IEnumerable<Review> GetAll()
        {
            return blogContext.Reviews.Find<Review>(new BsonDocument()).ToList();
        }
        public void Update(Review item)
        {
            blogContext.Reviews.ReplaceOne(doc => doc.Id == item.Id, item);
        }
    }
}