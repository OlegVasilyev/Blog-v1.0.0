using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.ViewModels
{
    public class SearchByTag
    {
        public List<Article> Articles { get; set; }

        public string TagText { get; set; }
    }
}