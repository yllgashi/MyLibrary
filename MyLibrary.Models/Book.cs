 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        public string Summary { get; set; }

        [Required]
        [MaxLength(4)]
        [RegularExpression(@"^\d$")]
        public short PublishedYear { get; set; }

        public string Publisher { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(15)]
        public string ISBN { get; set; }

        [RegularExpression(@"^\d$")]
        public int Pages { get; set; }

        [RegularExpression(@"^\d$")]
        public double UnitPrice { get; set; }

        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
    }
}