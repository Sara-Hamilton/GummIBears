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
        private GummiDbContext db = new GummiDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            var thisProduct = db.Products.FirstOrDefault(p => p.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
