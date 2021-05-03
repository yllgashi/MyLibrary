using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public short PublishedYear { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public double UnitPrice { get; set; }
    }
}
