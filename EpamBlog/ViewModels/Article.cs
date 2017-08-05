using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamBlog.ViewModels
{
    public class Article
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Date of publishing")]
        public DateTime Date { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public List<string> Tags { get; set; }
        public Article()
        {
            Tags = new List<string>();
        }
    }
}