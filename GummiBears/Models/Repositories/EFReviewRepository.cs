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
        GummiDbContext db = new GummiDbContext();

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }
    }
}
