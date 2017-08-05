using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Article : EntityIdBlog
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Tagg> Tags { get; set; }
        public Article()
        {
            Tags = new List<Tagg>();
        }
    }
}