using DataAccessLayerSQL.Context;
using DataAccessLayerInterfaces.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayerSQL.Repositories
{
    public class QuizRepository : IRepository<Quiz>
    {
        readonly private BlogContext context;
        public QuizRepository(BlogContext context)
        {
            this.context = context;
        }
        public void Create(Quiz item)
        {
            context.Quizes.Add(item);
        }

        public void Delete(int Id)
        {
            var user = context.Quizes.Find(Id);
            context.Quizes.Remove(user);
        }

        public IEnumerable<Quiz> Find(Func<Quiz, bool> predicate)
        {
            return context.Quizes.Where(predicate).ToList();
        }

        public Quiz Get(int Id)
        {
            return context.Quizes.Find(Id);
        }

        public IEnumerable<Quiz> GetAll()
        {
            return context.Quizes;
        }

        public void Update(Quiz item)
        {
            var user = context.Quizes.Find(item.Id);
            if(user !=null)
            {
                context.Entry(user).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}