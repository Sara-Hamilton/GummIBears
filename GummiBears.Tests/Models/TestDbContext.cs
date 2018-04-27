﻿using Microsoft.EntityFrameworkCore;
using GummiBears.Models;
using GummiBears.Data;

namespace GummiBears.Tests.Models
{
    public class TestDbContext : GummiDbContext
    {
        public override DbSet<Product> Products { get; set; }
        public override DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;database=gummi_bears_test;uid=root;pwd=root;");
        }
    }
}
