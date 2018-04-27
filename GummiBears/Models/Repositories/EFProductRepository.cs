using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBears.Data;
using Microsoft.EntityFrameworkCore;

namespace GummiBears.Models
{
    public class EFProductRepository : IProductRepository
    {
        GummiDbContext db = new GummiDbContext();

        public IQueryable<Product> Products
        { get { return db.Products; } }

        public Product Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        public Product Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Products.RemoveRange(db.Products);
            db.SaveChanges();
        }


    }
}
