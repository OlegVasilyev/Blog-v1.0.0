using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DataTransferObjects;
using DataAccessLayerInterfaces.Interfaces;
using BusinessLogicLayer.Infrastructure;
using AutoMapper;
using Entities.Models;

namespace BusinessLogicLayer.Service
{
    public class AnswerService : IAnswerService
    {
        IBlogRepository DataBase { get; }
        public AnswerService(IBlogRepository database)
        {
            this.DataBase = database;
        }
        public void UpdateAnswer(AnswerDTO answer)
        {
            if (DataBase.Answers.Get(answer.Id) == null)
                throw new ValidationException("Answer wasn't found", "");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, Answer>());
            var mapper = config.CreateMapper();
            var answerTemp = mapper.Map<Answer>(answer);

            DataBase.Answers.Update(answerTemp);

            DataBase.Save();
        }
    }
}
