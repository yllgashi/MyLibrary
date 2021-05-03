using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
    }
}
