using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GummiBears.Models;
using GummiBears.Data;

namespace GummiBears.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepository reviewRepo;

        public ReviewsController(IReviewRepository repo = null)
        {
            if(repo == null)
            {
                this.reviewRepo = new EFReviewRepository();
            }
            else
            {
                this.reviewRepo = repo;
            }
        }

        public IActionResult Index()
        {
            return View(reviewRepo.Reviews.ToList());
        }

        public IActionResult Create(int id)
        {
            ViewBag.ProductId = new SelectList(reviewRepo.Products, "ProductId", "Name");
            ViewBag.Reviews = reviewRepo.Reviews.Include(review => review.Product).ToList();
            //List<Review> model = reviewRepo.Reviews.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            reviewRepo.Save(review);
            Product product = new Product();
            product.ProductId = review.ProductId;
            var AllReviews = reviewRepo.Reviews;
            product.AverageRating = product.AverageReview(review.ProductId, AllReviews);
            reviewRepo.EditProduct(product);
            return RedirectToAction("Index");
        }
    }
}
