﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

        public Products (int productID, string productName, int price)
        {
            ProductID = productID;
            ProductName = productName;
            Price = price;
        }


    }
}
