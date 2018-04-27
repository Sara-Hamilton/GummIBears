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
                new Product(){ Name = "Giant Gummi", Description = "12 oz. gummi bear", Cost = 4.99m, ImageUrl = "https://i.ytimg.com/vi/1CbfG0epWHo/maxresdefault.jpg" },
                new Product(){ Name = "Green Gummies", Description = "16 oz. bag  of green gummi bears", Cost = 6.49m, ImageUrl = "https://www.ilovesugar.com/images/Green-Apple-Gummy-Bears-Candy.jpg"},
                new Product(){ Name = "Glitter Gummies", Description = "16 oz. bag  of pink and purple glittery gummi bears", Cost = 8, ImageUrl = "https://img0.etsystatic.com/165/1/8581691/il_340x270.1095861008_ny4h.jpg" },
                new Product(){ Name = "Shark Gummies", Description = "8 0z. bag of shark gummies", Cost = 4, ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.a-PODiqFhHX7pdJxcKuK6gHaFj&pid=15.1&P=0&w=236&h=178" },
                new Product(){ Name = "Gummi Worms", Description = "16 oz. bag of rainbow colored gummi worms", Cost = 6, ImageUrl = "http://25.media.tumblr.com/tumblr_m3295w1I751qfz9ceo1_500.jpg" },
                new Product(){ Name = "Red Hot Gummies", Description = "16 oz. bag  of red hot gummi bears", Cost = 3 , ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.flaaR4C9-l9cdbIWbVletQHaHa&pid=15.1&P=0&w=300&h=300"},
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
