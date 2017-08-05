using AutoMapper;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Interfaces;
using EpamBlog.Models;
using EpamBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpamBlog.Controllers
{
    public class ReviewsController : Controller
    {
        readonly IReviewService _reviewService;
        public ReviewsController(IReviewService service)
        {
            _reviewService = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<Review>>(_reviewService.GetReviews()));
        }

        [HttpPost]
        public ActionResult Index(Review review)
        {
            var configView = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var configDto = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>());
            var mapper = configDto.CreateMapper();

            try
            {
                review.Date = DateTime.UtcNow;
                var reviewDto = mapper.Map<ReviewDTO>(review);
                _reviewService.CreateReview(reviewDto);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property,ex.Message);
            }

            mapper = configView.CreateMapper();
            var model = mapper.Map<IEnumerable<Review>>(_reviewService.GetReviews());
            return PartialView("Partials/ReviewList", model);
        }
    }
}