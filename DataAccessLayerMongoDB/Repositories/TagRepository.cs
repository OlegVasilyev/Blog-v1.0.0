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
    public class TagRepository : IRepository<Tagg>
    {
        private readonly BlogContext blogContext;
        public TagRepository(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public Tagg Get(int Id)
        {
            BsonDocument filter = new BsonDocument("Id", Id);
            return blogContext.Tags.Find<Tagg>(filter).First();
        }

        public void Create(Tagg item)
        {
            blogContext.Tags.InsertOne(item);
        }
        public void Delete(int Id)
        {
            blogContext.Tags.DeleteOne(Builders<Tagg>.Filter.Where(x => x.Id == Id));
        }
        public IEnumerable<Tagg> Find(Func<Tagg, bool> predicate)
        {
            return blogContext.Tags.Find<Tagg>(predicate.ToBsonDocument()).ToList();
        }
        public IEnumerable<Tagg> GetAll()
        {
            return blogContext.Tags.Find<Tagg>(new BsonDocument()).ToList();
        }
        public void Update(Tagg item)
        {
            blogContext.Tags.ReplaceOne(doc => doc.Id == item.Id, item);
        }
    }
}