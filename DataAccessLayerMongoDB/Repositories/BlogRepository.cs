using DataAccessLayerInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using DataAccessLayerMongoDB.Context;

namespace DataAccessLayerMongoDB.Repositories
{
    public class BlogRepositories : IBlogRepository
    {
        private readonly BlogContext _context;
        private ArticleRepository articleRepository;
        private AnswerRepository answerRepository;
        private QuizRepository quizRepository;
        private TagRepository tagRepository;
        private ReviewRepository reviewrepRepository;
        public BlogRepositories(string connectionString)
        {
        }
        public IRepository<Article> Articles => articleRepository ?? (articleRepository = new ArticleRepository(_context));

        public IRepository<Review> Reviews => reviewrepRepository ?? (reviewrepRepository = new ReviewRepository(_context));

        public IRepository<Quiz> Quizes => quizRepository ?? (quizRepository = new QuizRepository(_context));

        public IRepository<Answer> Answers => answerRepository ?? (answerRepository = new AnswerRepository(_context));

        public IRepository<Tagg> Tags => tagRepository ?? (tagRepository = new TagRepository(_context));
        private bool disposed;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                   //-_-
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
