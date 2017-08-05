using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DataTransferObjects;
using EpamBlog.Controllers;

namespace NUnitTestEpamBlog.Controllers
{
    [TestFixture]
    public class ReviewsControllerTest
    {
        [Test]
        public void IndexGetViewNotNull()
        {
            // Arrange
            var mock = new Mock<IReviewService>();
            mock.Setup(a => a.GetReviews()).Returns(new List<ReviewDTO>());
            ReviewsController controller = new ReviewsController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void IndexGetViewModelNotNull()
        {
            // Arrange
            var mock = new Mock<IReviewService>();
            mock.Setup(a => a.GetReviews()).Returns(new List<ReviewDTO>());
            ReviewsController controller = new ReviewsController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            // ReSharper disable once PossibleNullReferenceException
            Assert.That(result.Model, Is.Not.Null);
        }
    }
}
