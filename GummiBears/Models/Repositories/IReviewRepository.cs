using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBears.Models
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        IQueryable<Product> Products { get; }
        Review Save(Review review);
        void DeleteAll();
        Product EditProduct(Product product);
    }
}
