using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Incorrect first name!")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Incorrect first name!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Incorrect last name!")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Incorrect last name!")]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public List<ClientOffer> ClientOffers { get; set; }
        public List<BookRent> BookRents { get; set; }
    }
}
