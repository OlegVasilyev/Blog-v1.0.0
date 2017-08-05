using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Authorname { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}