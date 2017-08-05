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

namespace EpamBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReviewController : Controller
    {
        readonly IReviewService _reviewService;
        public ReviewController(IReviewService service)
        {
            _reviewService = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReviewDTO, Review>();
            });
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<Review>>(_reviewService.GetReviews()));
        }

        [HttpPost]
        public ActionResult DeleteReview(int? id)
        {
            try
            {
                _reviewService.DeleteReview(id);
            }
            catch (ValidationException) { }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var mapper = config.CreateMapper();
            return PartialView("Partials/ReviewList", mapper.Map<IEnumerable<Review>>(_reviewService.GetReviews()));
        }
    }
}