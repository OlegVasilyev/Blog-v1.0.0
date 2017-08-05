using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IArticleService
    {
        ArticleDTO GetArticle(int? Id);
        IEnumerable<ArticleDTO> GetArticles();
        IEnumerable<ArticleDTO> GetArticles(string tag);
        void CreateArticle(ArticleDTO articleDto);
        void DeleteArticle(int? Id);
    }
}
