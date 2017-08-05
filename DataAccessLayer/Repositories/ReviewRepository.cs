using DataAccessLayerSQL.Context;
using DataAccessLayerInterfaces.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayerSQL.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        readonly private BlogContext context;
        public ReviewRepository(BlogContext context)
        {
            this.context = context;
        }
        public void Create(Review item)
        {
            context.Reviews.Add(item);
        }
        public void Delete(int Id)
        {
            var review = context.Reviews.Find(Id);
            context.Reviews.Remove(review);
        }

        public IEnumerable<Review> Find(Func<Review, bool> predicate)
        {
            return context.Reviews.Where(predicate).ToList();
        }

        public Review Get(int Id)
        {
            return context.Reviews.Find(Id);
        }

        public IEnumerable<Review> GetAll()
        {
            return context.Reviews;
        }

        public void Update(Review item)
        {
            var review = context.Reviews.Find(item.Id);
            if(review != null)
            {
                context.Entry(review).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}