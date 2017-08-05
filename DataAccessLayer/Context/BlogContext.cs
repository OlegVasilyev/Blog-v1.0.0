using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Entities.Models;
using DataAccessLayerInterfaces.Interfaces;

namespace DataAccessLayerSQL.Context
{
    /// <summary>
    /// Context for working with related database
    /// </summary>
    public class BlogContext : DbContext, IContext
    {
        public BlogContext(string connctionString) : base(connctionString) { }
        public virtual DbSet<Quiz> Quizes { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Tagg> Tags { get; set; }
        /// <summary>
        /// Static constructor for setting DB initializer
        /// </summary>
        static BlogContext()
        {
            Database.SetInitializer(new BlogInitializer());
        }
        public BlogContext() { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasMany(c => c.Tags)
                .WithMany(s => s.Articles)
                .Map(t => t.MapLeftKey("ArticleId")
                .MapRightKey("TagId")
                .ToTable("ArticleTag"));
        }
    }

}