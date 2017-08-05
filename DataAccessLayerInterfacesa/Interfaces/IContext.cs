using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerInterfaces.Interfaces
{
    public interface IContext
    {
          DbSet<Quiz> Quizes { get; set; }
          DbSet<Article> Articles { get; set; }
          DbSet<Answer> Answers { get; set; }
          DbSet<Review> Reviews { get; set; }
          DbSet<Tagg> Tags { get; set; }
    }
}
