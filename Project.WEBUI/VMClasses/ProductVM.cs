﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.VMClasses
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }

    }
}