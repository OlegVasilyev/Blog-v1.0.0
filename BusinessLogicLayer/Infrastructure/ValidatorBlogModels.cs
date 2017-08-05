using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Infrastructure
{
    public static class ValidatorBlogModels
    {
        public static void ValidateArticleModel(ArticleDTO articleDto)
        {
            if (articleDto == null)
                throw new ValidationException("Cannot create article from null", "");
            if (String.IsNullOrEmpty(articleDto.Text))
                throw new ValidationException("This property cannot be null", "Text");
            if (String.IsNullOrEmpty(articleDto.Name))
                throw new ValidationException("This property cannot be null", "Name");
            if (articleDto.Date == null)
                throw new ValidationException("This property cannot be null", "Date");
        }
        public static void ValidateQuizModel(QuizDTO quizDto)
        {
            if (quizDto == null)
                throw new ValidationException("Cannot create article from null", "");
            if (quizDto.Email == null)
                throw new ValidationException("This property cannot be null", "Email");
            if (quizDto.Name == null)
                throw new ValidationException("This property cannot be null", "Name");
            if (quizDto.Sex == null)
                throw new ValidationException("This property cannot be null", "Sex");
            if (quizDto.Surname == null)
                throw new ValidationException("This property cannot be null", "Surname");
        }
        public static void ValidateReviewModel(ReviewDTO reviewDto)
        {
            if (reviewDto == null)
                throw new ValidationException("Cannot create article from null", "");
            if (reviewDto.Text == null)
                throw new ValidationException("This property cannot be null", "Text");
            if (reviewDto.Authorname == null)
                throw new ValidationException("This property cannot be null", "AuthorName");
            if (reviewDto.Date == null)
                throw new ValidationException("This property cannot be null", "Date");
        }
    }
}
