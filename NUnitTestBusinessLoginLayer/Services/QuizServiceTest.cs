using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Service;
using DataAccessLayerInterfaces.Interfaces;
using Entities.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBusinessLoginLayer.Services
{
    [TestFixture]
    class QuizServiceTest
    {
        [Test]
        [TestCase(null, null, null, null, null, null, null, null, null)]
        [TestCase(null, null, null, null, "04.08.2017", null, null, null, null)]
        [TestCase(null, null, null,null, "04.08.2017", "test",null, null, null)]
        [TestCase(null, null, null,"test", "04.08.2017", null, null, null, null)]
        public void CreateQuizValidation(string name, string surname, string email, string sex, DateTime birth, string number, bool smoke, string position, string about)
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Quizes.Create(It.IsAny<Quiz>()));

            var _quizService = new QuizService(mockBlogRepository.Object);
            Assert.Throws<ValidationException>(() => _quizService.CreateQuiz(new QuizDTO() { Name = name, Surname = surname, Email = email, DateBirt = birth, NumberTelephone = number, Sex = sex, About =about, Position = position, Smoke= smoke }));
        }
        [Test]
        [TestCase(1)]
        [TestCase(-10)]
        [TestCase(0)]
        [TestCase(100)]
        public void GetQuiz(int? Id)
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Quizes.Get(It.IsAny<int>())).Returns(new Quiz());

            var _quizService = new QuizService(mockBlogRepository.Object);
            var result = _quizService.GetQuiz(Id);

            Assert.That(result, Is.TypeOf(typeof(QuizDTO)));
        }
        [Test]
        public void GetQuizes()
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Quizes.GetAll()).Returns(new List<Quiz>());

            var _quizService = new QuizService(mockBlogRepository.Object);
            var result = _quizService.GetQuizs();

            Assert.That(result, Is.TypeOf(typeof(List<QuizDTO>)));
        }

        [Test]
        [TestCase(null)]
        [TestCase(-1)]
        public void DeleteArticle(int? Id)
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Quizes.Get(-1)).Returns((Quiz)null);

            var _quizService = new QuizService(mockBlogRepository.Object);

            Assert.Throws<ValidationException>(() => _quizService.DeleteQuiz(Id));
        }
        [Test]
        [TestCase(null, null, null, null, null, null, null, null, null)]
        [TestCase(null, null, null, null, "04.08.2017", null, null, null, null)]
        [TestCase(null, null, null, null, "04.08.2017", "test", null, null, null)]
        [TestCase(null, null, null, "test", "04.08.2017", null, null, null, null)]
        public void UpdateQuizValidation(string name, string surname, string email, string sex, DateTime birth, string number, bool smoke, string position, string about)
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Quizes.Update(It.IsAny<Quiz>()));

            var _quizService = new QuizService(mockBlogRepository.Object);
            Assert.Throws<ValidationException>(() => _quizService.UpdateQuiz(new QuizDTO() { Name = name, Surname = surname, Email = email, DateBirt = birth, NumberTelephone = number, Sex = sex, About = about, Position = position, Smoke = smoke }));
        }
    }
}
