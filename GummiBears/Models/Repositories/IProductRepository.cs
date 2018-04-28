using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBears.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Review> SortedReviews { get; }
        Product Save(Product product);
        Product Edit(Product product);
        void Remove(Product product);
        void DeleteAll();
    }
}
