using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayerInterfaces.Interfaces
{

    public interface IBlogRepository : IDisposable
    {
        IRepository<Article> Articles { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Quiz> Quizes {get;}
        IRepository<Answer> Answers { get; }
        IRepository<Tagg> Tags { get; }
        void Save();
    }
}