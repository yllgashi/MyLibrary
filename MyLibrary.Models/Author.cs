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
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression("^[A-Z][a-zA-Z]*$")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression("^[A-Z][a-zA-Z]*$")]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public List<Book> Books { get; set; }
    }
}
