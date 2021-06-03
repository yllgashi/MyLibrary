using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class ClientOffer
    {
        public Offer Offer { get; set; }

        [Required]
        public DateTime AgreementDate { get; set; }
    }
}
