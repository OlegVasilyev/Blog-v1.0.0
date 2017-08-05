using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamBlog.ViewModels
{
    public class Review
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Author")]
        public string Authorname { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [DisplayName("Date of publishing")]
        public DateTime Date { get; set; }
    }
}