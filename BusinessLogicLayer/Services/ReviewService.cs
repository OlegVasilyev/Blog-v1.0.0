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
    public class ReviewService : IReviewService
    {
        IBlogRepository DataBase { get; }
        public ReviewService(IBlogRepository database)
        {
            this.DataBase = database;
        }
        public void CreateReview(ReviewDTO reviewDto)
        {
            ValidatorBlogModels.ValidateReviewModel(reviewDto);
            Mapper.Initialize(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var reviewNew = Mapper.Map<Review>(reviewDto);
            DataBase.Reviews.Create(reviewNew);
            DataBase.Save();
        }

        public void DeleteReview(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Id is null", "");
            if (!DataBase.Reviews.Find(x => x.Id == Id).Any())
                throw new ValidationException("Review wasn't found", "");
            DataBase.Reviews.Delete((int)Id);
            DataBase.Save();
        }

        public IEnumerable<ReviewDTO> GetReviews()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>());
            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<ReviewDTO>>(DataBase.Reviews.GetAll());
        }

    }
}
