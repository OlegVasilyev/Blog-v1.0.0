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
    class AnswerServiceTest
    {
        [Test]
        [TestCase(1, 1, null)]
        [TestCase(1, null, "test")]
        [TestCase(null, 1, "test")]
        public void UpdateQuizValidation(int quiention, int votes , string text)
        {
            var mockBlogRepository = new Mock<IBlogRepository>();
            mockBlogRepository.Setup(m => m.Answers.Update(It.IsAny<Answer>()));

            var _answerService = new AnswerService(mockBlogRepository.Object);
            Assert.Throws<ValidationException>(() => _answerService.UpdateAnswer(new AnswerDTO() { QuestionId = quiention, VotesCount = votes, Text = text }));
        }
    }
}
