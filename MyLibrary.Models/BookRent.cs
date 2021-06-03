using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class BookRent
    {
        public int BookRentId { get; set; }

        [RegularExpression(@"^\d$")]
        [Range(1, 999999, ErrorMessage = "Book id!")]
        public int BookId { get; set; }

        [RegularExpression(@"^\d$")]
        [Range(1, 999999, ErrorMessage = "Book id!")]
        public int ClientId { get; set; }
        public Book Book { get; set; }
        public Client Client { get; set; }

        [Required]
        public DateTime RentDate { get; set; }
    }
}
