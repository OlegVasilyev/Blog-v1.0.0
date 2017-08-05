using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DataTransferObjects;
using AutoMapper;
using Entities.Models;
using BusinessLogicLayer.Infrastructure;
using DataAccessLayerInterfaces.Interfaces;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace BusinessLogicLayer.Service
{
    public class QuizService : IQuizService
    {
        IBlogRepository DataBase { get; }
        public QuizService(IBlogRepository database)
        {
            this.DataBase = database;
        }
        public void CreateQuiz(QuizDTO quizDto)
        {
            ValidatorBlogModels.ValidateQuizModel(quizDto);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuizDTO, Quiz>());
            var mapper = config.CreateMapper();
            var quizNew = mapper.Map<Quiz>(quizDto);
            DataBase.Quizes.Create(quizNew);
            DataBase.Save();
        }

        public void DeleteQuiz(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Id is null", "");
            if (!DataBase.Quizes.Find(x => x.Id == Id).Any())
                throw new ValidationException("Quiz wasn't found", "");
            DataBase.Quizes.Delete((int)Id);
            DataBase.Save();
        }

        public QuizDTO GetQuiz(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Quiz's id wasn't set", "");
            var quizemp = DataBase.Quizes.Get(Id.Value);
            if (quizemp == null)
                throw new ValidationException("Quiz wasn't found", "");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Quiz, QuizDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<QuizDTO>(quizemp);
        }

        public IEnumerable<QuizDTO> GetQuizs()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Quiz, QuizDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<QuizDTO>>(DataBase.Quizes.GetAll());
        }

        public void SendMailResult(QuizDTO quizDto)
        {
            string server = ConfigurationManager.AppSettings["server"];
            string port = ConfigurationManager.AppSettings["port"];
            string login = ConfigurationManager.AppSettings["login"];
            string password = ConfigurationManager.AppSettings["password"];

            MailMessage mail = new MailMessage();
            mail.Subject = "Result";
            mail.From = new MailAddress(login);
            mail.Body = quizDto.ToString();
            mail.To.Add(new MailAddress(quizDto.Email));
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = server;
            client.Port = Convert.ToInt32(port);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(login, password);

            try
            {
                client.Send(mail);
            }
            catch { }
        }

        public void UpdateQuiz(QuizDTO quizDto)
        {
            if (DataBase.Quizes.Get(quizDto.Id) == null)
                throw new ValidationException("Quiz wasn't found", "");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuizDTO, Quiz>());
            var mapper = config.CreateMapper();
            var quizTemp = mapper.Map<Answer>(quizDto);

            DataBase.Answers.Update(quizTemp);

            DataBase.Save();
        }
    }
}
