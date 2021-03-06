﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GummiBears.Data;

namespace GummiBears.Models
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {
            this.Reviews = new HashSet<Review>();
        }

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal? Cost { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public decimal AverageRating { get; set; }


        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                return this.ProductId.Equals(newProduct.ProductId);
            }
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }

        public decimal AverageReview()
        {
            return this.Reviews.Average(r => r.Rating);
        }

        public decimal AverageReview(int productId, IQueryable<Review> AllReviews)
        {
            List<decimal> ratingsList = new List<decimal>();
            foreach (Review review in AllReviews)
            {
                if(review.ProductId == productId)
                {
                    ratingsList.Add(review.Rating);
                }
            }
            decimal result = ratingsList.Average();

            return result;
        }

    }
}
