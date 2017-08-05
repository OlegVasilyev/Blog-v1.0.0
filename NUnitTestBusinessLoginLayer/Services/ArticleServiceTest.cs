using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using BusinessLogicLayer.DataTransferObjects;
using DataAccessLayerInterfaces.Interfaces;
using Entities.Models;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Service;

namespace UnitTestBusinessLoginLayer.Services
{
    [TestFixture]
    class ArticleServiceTest
    {
        [Test]
        [TestCase(null, null, null)]
        [TestCase(null, "04.08.2017", null)]
        [TestCase(null, "04.08.2017", "test")]
        [TestCase("test", "04.08.2017", null)]
        public void CreateArticleValidation(string name, DateTime date, string text )
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Articles.Create(It.IsAny<Article>()));

            var _articleService = new ArticleService(mockBlogRepository.Object);
            Assert.Throws<ValidationException>(() => _articleService.CreateArticle(new ArticleDTO() { Name = name, Date = date, Text = text }));
        }
        [Test]
        [TestCase(1)]
        [TestCase(-10)]
        [TestCase(0)]
        [TestCase(100)]
        public void GetArticle(int? Id)
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Articles.Get(It.IsAny<int>())).Returns(new Article());

            var _articleService = new ArticleService(mockBlogRepository.Object);
            var result = _articleService.GetArticle(Id);

            Assert.That(result, Is.TypeOf(typeof(ArticleDTO)));
        }
        [Test]
        public void GetArticles()
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Articles.GetAll()).Returns(new List<Article>());

            var _articleService = new ArticleService(mockBlogRepository.Object);
            var result = _articleService.GetArticles();

            Assert.That(result, Is.TypeOf(typeof(List<ArticleDTO>)));
        }

        [Test]
        [TestCase(null)]
        [TestCase(-1)]
        public void DeleteArticle(int? Id)
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Articles.Get(-1)).Returns((Article)null);

            var _articleService = new ArticleService(mockBlogRepository.Object);

            Assert.Throws<ValidationException>(() => _articleService.DeleteArticle(Id));
        }
    }
}
