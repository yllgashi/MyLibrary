using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class ClientOffer
    {
        public int ClientOfferId { get; set; }
        public int ClientId { get; set; }
        public int OfferId { get; set; }
        public DateTime AgreementDate { get; set; }
    }
}
