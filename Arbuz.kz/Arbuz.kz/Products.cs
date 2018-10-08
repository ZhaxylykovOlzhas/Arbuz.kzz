using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Arbuz.KZ
{
    public class Products
    {
        public string Name { get; set; }
        public string Catalog { get; set; }
        public int Price { get; set; }
        public Products() { }
        public Products(string name, string catalog, int price)
        {
            Name = name;
            Catalog = catalog;
            Price = price;
        }
    }
}