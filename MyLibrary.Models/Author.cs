using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Incorrect first name!")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Incorrect first name!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "Incorrect last name!")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Incorrect last name!")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Book> Books { get; set; }
    }
}
