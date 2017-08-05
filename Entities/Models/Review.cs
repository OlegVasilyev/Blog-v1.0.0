using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class Review : EntityIdBlog
    {
        public string Authorname { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}