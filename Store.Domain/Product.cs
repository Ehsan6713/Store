﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}