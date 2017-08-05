using DataAccessLayerInterfaces.Interfaces;
using DataAccessLayerSQL.Context;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayerSQL.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {
        private readonly BlogContext context;
        public AnswerRepository(BlogContext context)
        {
            this.context = context;
        }

        public void Create(Answer item)
        {
            context.Answers.Add(item);
        }

        public void Delete(int Id)
        {
            var answer = context.Answers.Find(Id);
            if (answer != null)
                context.Answers.Remove(answer);
        }

        public IEnumerable<Answer> Find(Func<Answer, bool> predicate)
        {
            return context.Answers.Where(predicate).ToList();
        }

        public Answer Get(int Id)
        {
            return context.Answers.Find(Id);
        }

        public IEnumerable<Answer> GetAll()
        {
            return context.Answers;
        }

        public void Update(Answer item)
        {
            var temp = context.Answers.Find(item.Id);
            if(temp != null)
            {
                context.Entry(temp).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}