using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Tagg : EntityIdBlog
    {
        public string Text { get; set; }
        public virtual ICollection<Article>  Articles { get; set; }
        public Tagg()
        {
            Articles = new List<Article>();
        }
    }
}