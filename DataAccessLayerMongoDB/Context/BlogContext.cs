using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using Entities.Models;
using DataAccessLayerInterfaces.Interfaces;

namespace DataAccessLayerMongoDB.Context
{
    public class BlogContext
    {
        public const string CONNECTION_STRING_NAME = "Blog";
        public const string DATABASE_NAME = "blog";
        public const string ARTICLES_COLLECTION_NAME = "articles";
        public const string ANSWERS_COLLECTION_NAME = "answers";
        public const string REVIEWS_COLLECTION_NAME = "reviews";
        public const string QUIZES_COLLECTION_NAME = "quizes";
        public const string TAGS_COLLECTION_NAME = "tags";

        private static readonly IMongoClient client;
        private static readonly IMongoDatabase database;

        static BlogContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            client = new MongoClient(connectionString);
            database = client.GetDatabase(DATABASE_NAME);
        }
        public void SaveChanges()
        {
            //-_-
        }
        public IMongoClient Client
        {
            get { return client; }
        }

        public IMongoCollection<Article> Articles
        {
            get { return database.GetCollection<Article>(ARTICLES_COLLECTION_NAME); }
        }
        public IMongoCollection<Answer> Answers
        {
            get { return database.GetCollection<Answer>(ANSWERS_COLLECTION_NAME); }
        }
        public IMongoCollection<Review> Reviews
        {
            get { return database.GetCollection<Review>(REVIEWS_COLLECTION_NAME); }
        }
        public IMongoCollection<Quiz> Quizes
        {
            get { return database.GetCollection<Quiz>(QUIZES_COLLECTION_NAME); }
        }
        public IMongoCollection<Tagg> Tags
        {
            get { return database.GetCollection<Tagg>(TAGS_COLLECTION_NAME); }
        }
    }
}