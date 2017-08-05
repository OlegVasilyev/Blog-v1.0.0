using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Service;
using DataAccessLayerInterfaces.Interfaces;
using Entities.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTestBusinessLoginLayer.Services
{
    [TestFixture]
    class ReviewServiceTest
    {
        [Test]
        [TestCase(null, null, null)]
        [TestCase(null, null, "04.08.2017")]
        [TestCase(null, "test", "04.08.2017")]
        [TestCase("test", null, "04.08.2017")]
        public void CreateReviewValidation(string authorname, string text, DateTime date)
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Reviews.Create(It.IsAny<Review>()));

            var _reviewService = new ReviewService(mockBlogRepository.Object);
            Assert.Throws<ValidationException>(() => _reviewService.CreateReview(new ReviewDTO() { Authorname = authorname, Text = text, Date = date  }));
        }
        [Test]
        public void GetReview()
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Reviews.GetAll()).Returns(new List<Review>());

            var _reviewService = new ReviewService(mockBlogRepository.Object);
            var result = _reviewService.GetReviews();

            Assert.That(result, Is.TypeOf(typeof(List<ReviewDTO>)));
        }
        [Test]
        [TestCase(null)]
        [TestCase(-1)]
        public void DeleteReview(int? Id)
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Reviews.Get(-1)).Returns((Review)null);

            var _reviewService = new ReviewService(mockBlogRepository.Object);

            Assert.Throws<ValidationException>(() => _reviewService.DeleteReview(Id));
        }
    }
}
