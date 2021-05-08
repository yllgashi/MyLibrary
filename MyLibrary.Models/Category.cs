﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; }
    }
}
