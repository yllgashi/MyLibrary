using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Incorrect first name!")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Incorrect first name!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Incorrect last name!")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Incorrect last name!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Incorrect email!")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password is too long!")]
        [MinLength(8, ErrorMessage = "Password is too small!")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
