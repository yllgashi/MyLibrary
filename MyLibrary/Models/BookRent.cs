using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class BookRent
    {
        public int BookRentId { get; set; }
        public int BookId { get; set; }
        public int ClientId { get; set; }
        public DateTime RentDate { get; set; }
    }
}
