using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IQuizService
    {
        void CreateQuiz(QuizDTO quizDto);
        void SendMailResult(QuizDTO quizDto);
        QuizDTO GetQuiz(int? Id);
        IEnumerable<QuizDTO> GetQuizs();
        void UpdateQuiz(QuizDTO quizDto);
        void DeleteQuiz(int? Id);
    }
}
