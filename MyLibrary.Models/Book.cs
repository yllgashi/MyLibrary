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

        [Required(ErrorMessage = "Published year is required")]
        [MaxLength(4, ErrorMessage = "Year is incorrect!")]
        [RegularExpression(@"^\d$", ErrorMessage = "Year is incorrect!")]
        public short PublishedYear { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        [MaxLength(40, ErrorMessage = "Publisher is incorrect!")]
        public string Publisher { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        [MaxLength(15, ErrorMessage = "ISBN is incorrect!")]
        [MinLength(15, ErrorMessage = "ISBN is incorrect!")]
        public string ISBN { get; set; }

        [RegularExpression(@"^\d$")]
        [MaxLength(3, ErrorMessage = "Number of pages is incorrect")]
        public int Pages { get; set; }

        [RegularExpression(@"^\d$")]
        public double UnitPrice { get; set; }

        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
    }
}