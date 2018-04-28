using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBears.Models;
using GummiBears.Data;

namespace GummiBears.Controllers
{
    public class HomeController : Controller
    {
        private GummiDbContext db = new GummiDbContext();
        public IActionResult Index()
        {
            //var test = db.Products.GroupBy(ProductId => ProductId).OrderBy(ProductId => ProductId.Count()).Take(3).ToList();
            //List<Product> model = new List<Product>(test);
            List<Product> model = db.Products.Take(3).ToList();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
