using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Incorrect description!")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Incorrect description!")]
        public string Description { get; set; }
        public List<Book> Books { get; set; }
    }
}
