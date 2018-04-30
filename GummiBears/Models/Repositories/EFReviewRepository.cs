using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBears.Data;
using Microsoft.EntityFrameworkCore;

namespace GummiBears.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        GummiDbContext db;
        public EFReviewRepository()
        {
            db = new GummiDbContext();
        }

        public EFReviewRepository(GummiDbContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public IQueryable<Product> Products
        {  get { return db.Products; } }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public void DeleteAll()
        {
            db.Reviews.RemoveRange(db.Reviews);
            db.SaveChanges();
        }

        public Product EditProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }
    }
}
