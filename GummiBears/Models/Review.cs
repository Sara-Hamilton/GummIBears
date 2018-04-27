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
    }
}
