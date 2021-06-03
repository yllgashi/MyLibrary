using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Offer
    {
        public int OfferId { get; set; }

        [RegularExpression(@"^\d$")]
        [Range(1, 99999, ErrorMessage = "Incorrect value!")]
        public int Days{ get; set; }

        [Required]
        [Range(typeof(double), "0.00", "9999.00")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Incorrect description!")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Incorrect description!")]
        public string Description { get; set; }
    }
}
