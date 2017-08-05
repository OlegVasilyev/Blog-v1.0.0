using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Answer : EntityIdBlog
    {
        public int QuestionId { get; set; }
        public string  Text { get; set; }
        public int VotesCount { get; set; }

    }
}