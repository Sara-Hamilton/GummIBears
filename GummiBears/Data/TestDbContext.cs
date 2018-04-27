using Microsoft.EntityFrameworkCore;
using GummiBears.Models;
using GummiBears.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GummiBears.Tests.Models
{
    public class TestDbContext : GummiDbContext
    {
        public override DbSet<Product> Products { get; set; }
        public override DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost; Port=8889; database=gummi_bears_test;uid=root;pwd=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }
    }
}
