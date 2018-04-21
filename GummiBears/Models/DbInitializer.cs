using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GummiBears.Models;

namespace GummiBears.Data
{
    public class DbInitializer
    {
        public static void Initialize(GummiDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product(){ Name = "Giant Gummi", Description = "12 oz. gummi bear", Cost = 499 },
                new Product(){ Name = "Green Gummies", Description = "16 oz. bag  of green gummi bears", Cost = 6 },
                new Product(){ Name = "Glitter Gummies", Description = "16 oz. bag  of pink and purple glittery gummi bears", Cost = 8 },
                new Product(){ Name = "Shark Gummies", Description = "8 0z. bag of shark gummies", Cost = 4 },
                new Product(){ Name = "Gummi Worms", Description = "16 oz. bag of rainbow colored gummi worms", Cost = 6 },
                new Product(){ Name = "Red Hot Gummies", Description = "16 oz. bag  of red hot gummi bears", Cost = 3 },
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
