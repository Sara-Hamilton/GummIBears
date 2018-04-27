using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBears.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content_Body { get; set; }

        [Range(1,5)]
        public decimal Rating { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public override bool Equals(System.Object otherReview)
        {
            if (!(otherReview is Review))
            {
                return false;
            }
            else
            {
                Review newReview = (Review)otherReview;
                return this.ReviewId.Equals(newReview.ReviewId);
            }
        }

        public override int GetHashCode()
        {
            return this.ReviewId.GetHashCode();
        }

        public Boolean VerifyRating()
        {
            if (this.Rating > 0 && this.Rating < 6)
            {
                return true;
            }
            else return false;
        }

        public Boolean VerifyContentLength()
        {
            if (this.Content_Body.Length > 255)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
