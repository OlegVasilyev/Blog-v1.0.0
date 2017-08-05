using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EpamBlog.ViewModels
{
    public class Answer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string  Text { get; set; }
        [Required]
        [DisplayName("Votes Count")]
        public int VotesCount { get; set; }

    }
}