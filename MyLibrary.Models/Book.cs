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

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title is incorrect!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Summary is required")]
        [StringLength(100, ErrorMessage = "Summary is incorrect!")]
        public string Summary { get; set; }

        [Range(1, 5000, ErrorMessage = "Year is incorrect!")]
        [RegularExpression(@"^\d$", ErrorMessage = "Year is incorrect!")]
        public short PublishedYear { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        [MaxLength(50, ErrorMessage = "Publisher is incorrect!")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [MaxLength(15, ErrorMessage = "ISBN is incorrect!")]
        [MinLength(15, ErrorMessage = "ISBN is incorrect!")]
        public string ISBN { get; set; }

        [RegularExpression(@"^\d$")]
        [Range(1, 10000, ErrorMessage = "Incorrect value!")]
        public int Pages { get; set; }

        [Required]
        [Range(typeof(double), "0.00", "999.00")]
        public double UnitPrice { get; set; }

        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
    }
}