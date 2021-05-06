using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class BookRent
    {
        public Book Book { get; set; }
        public DateTime RentDate { get; set; }
    }
}
