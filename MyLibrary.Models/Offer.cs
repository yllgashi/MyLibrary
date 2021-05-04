using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        public int Days{ get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
