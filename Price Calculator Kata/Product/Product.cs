using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Product
{
    public class Product : IProduct
    {

        public string name { get; set; }
        public int UPC { get; set; }
        public float price { get; set; }

        public Product(string name, int UPC, float price)
        {
            this.name = name;
            this.UPC = UPC;
            this.price = price.Round(2);
        }

    }
}
