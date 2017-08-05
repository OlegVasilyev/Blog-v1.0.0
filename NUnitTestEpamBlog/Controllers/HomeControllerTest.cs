using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using EpamBlog.Controllers;
using Moq;
using NUnit.Framework;
using NUnitTestEpamBlog.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NUnitTestEpamBlog.Controllers
{
    [TestFixture]
    class HomeControllerTest
    {
        [Test]
        public void IndexGetViewNotNull()
        {
            // Arrange
            var mock = new Mock<IArticleService>();
            mock.Setup(a => a.GetArticles()).Returns(new List<ArticleDTO>());
            var controller = new HomeController(mock.Object);
            controller.ControllerContext = new TestControllerContext(controller, new FormCollection());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public void IndexGetViewModelNotNull()
        {
            // Arrange
            var mock = new Mock<IArticleService>();
            mock.Setup(a => a.GetArticles()).Returns(new List<ArticleDTO>());
            var controller = new HomeController(mock.Object);
            controller.ControllerContext = new TestControllerContext(controller, new FormCollection());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            // ReSharper disable once PossibleNullReferenceException
            Assert.That(result.Model, Is.Not.Null);
        }
        public void SearchTagViewModelNotNull()
        {
            // Arrange
            var mockRentService = new Mock<IArticleService>();
            mockRentService.Setup(a => a.GetArticles()).Returns(new List<ArticleDTO>());

            var controller = new HomeController(mockRentService.Object);
            controller.ControllerContext = new TestControllerContext(controller, new FormCollection());

            // Act
            PartialViewResult result = controller.Search("EF6") as PartialViewResult;

            // Assert
            // ReSharper disable once PossibleNullReferenceException
            Assert.That(result.Model, Is.Not.Null);
        }
    }
}
