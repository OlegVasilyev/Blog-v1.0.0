using DataAccessLayerSQL.Context;
using DataAccessLayerInterfaces.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayerSQL.Repositories
{
    public class TagRepository : IRepository<Tagg>
    {
        private readonly BlogContext context;
        public TagRepository(BlogContext context)
        {
            this.context = context;
        }
        public void Create(Tagg item)
        {
            context.Tags.Add(item);
        }

        public void Delete(int Id)
        {
            var tag = context.Tags.Find(Id);
            context.Tags.Remove(tag);
        }

        public IEnumerable<Tagg> Find(Func<Tagg, bool> predicate)
        {
            return context.Tags.Where(predicate).ToList();
        }

        public Tagg Get(int Id)
        {
            return context.Tags.Find(Id);
        }

        public IEnumerable<Tagg> GetAll()
        {
            return context.Tags;
        }

        public void Update(Tagg item)
        {
            var temp = context.Tags.Find(item.Id);
            if(temp!=null)
            {
                context.Entry(temp).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}