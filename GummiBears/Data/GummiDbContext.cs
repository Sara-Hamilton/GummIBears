using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GummiBears.Models;

namespace GummiBears.Data
{
    public class GummiDbContext : DbContext
    {
        public GummiDbContext()
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=gummi_bears;uid=root;pwd=root;");
        }

        public GummiDbContext(DbContextOptions<GummiDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Review>().ToTable("Reviews");
            base.OnModelCreating(builder);
        }
    }
}
