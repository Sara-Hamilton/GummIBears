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
                new Product(){ Name = "Giant Gummi", Description = "12 oz. gummi bear", Cost = 4.99m, ImageUrl = "https://i.ytimg.com/vi/1CbfG0epWHo/maxresdefault.jpg", AverageRating = 5.0m },
                new Product(){ Name = "Green Gummies", Description = "16 oz. bag  of green gummi bears", Cost = 6.49m, ImageUrl = "https://www.ilovesugar.com/images/Green-Apple-Gummy-Bears-Candy.jpg", AverageRating = 5.0m},
                new Product(){ Name = "Glitter Gummies", Description = "16 oz. bag  of pink and purple glittery gummi bears", Cost = 8, ImageUrl = "https://img0.etsystatic.com/165/1/8581691/il_340x270.1095861008_ny4h.jpg", AverageRating = 3.0m },
                new Product(){ Name = "Shark Gummies", Description = "8 0z. bag of shark gummies", Cost = 4, ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.a-PODiqFhHX7pdJxcKuK6gHaFj&pid=15.1&P=0&w=236&h=178", AverageRating = 5.0m },
                new Product(){ Name = "Gummi Worms", Description = "16 oz. bag of rainbow colored gummi worms", Cost = 6, ImageUrl = "http://25.media.tumblr.com/tumblr_m3295w1I751qfz9ceo1_500.jpg", AverageRating = 4.0m},
                new Product(){ Name = "Red Hot Gummies", Description = "16 oz. bag  of red hot gummi bears", Cost = 3 , ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.flaaR4C9-l9cdbIWbVletQHaHa&pid=15.1&P=0&w=300&h=300", AverageRating = 2.0m}
            };

            var reviews = new Review[]
            {
                new Review() { ReviewId = 1, Title = "Love It!", Author = "Sara", Content_Body = "This is the best gummy bear I have ever had.", Rating = 5, ProductId = 1},
                new Review() { ReviewId = 2, Title = "Yummy Gummy", Author = "Jim", Content_Body = "This is great.  You should buy it.", Rating = 5, ProductId = 1},
                new Review() { ReviewId = 3, Title = "Meh", Author = "Megan", Content_Body = "These are OK.  I've had better", Rating = 3, ProductId = 3},
                new Review() { ReviewId = 4, Title = "Go Glitter!", Author = "Kevin", Content_Body = "Everything's better with glitter.  These gummy bears are no exception.", Rating = 3, ProductId = 3},
                new Review() { ReviewId = 5, Title = "Gross", Author = "Jake", Content_Body = "Who wants to eat glitter?", Rating = 1, ProductId = 3},
                new Review() { ReviewId = 6, Title = "Great Green Gummies", Author = "George", Content_Body = "These are great.  I can't stop eating them.", Rating = 5, ProductId = 3},
                new Review() { ReviewId = 7, Title = "I Like These", Author = "Jimmy", Content_Body = "Gummies are the best.", Rating = 5, ProductId = 2},
                new Review() { ReviewId = 8, Title = "good", Author = "Candy", Content_Body = "5 stars", Rating = 5, ProductId = 4},
                new Review() { ReviewId = 9, Title = "Buy these", Author = "Penny", Content_Body = "good eatin'", Rating = 4, ProductId = 5},
                new Review() { ReviewId = 10, Title = "Good Gummies", Author = "Lucy", Content_Body = "These are pretty good", Rating = 3, ProductId = 6},
                new Review() { ReviewId = 11, Title = "Yuck", Author = "Kyle", Content_Body = "These are gross", Rating = 1, ProductId = 6},
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }

            foreach (Review r in reviews)
            {
                context.Reviews.Add(r);
            }

            context.SaveChanges();
        }
    }
}
