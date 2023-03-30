using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class ProductPrinter
    {
        private Product product { get; set; }

        public ProductPrinter(Product product) { 
            this.product = product;
        }

        public void PrintPrice()
        {
            Console.Write($"Product price reported as ${product.price:#.##} before tax " +
                $"and ${product.CalculatePriceWithTax():#.##} after {Product.taxPercentage * 100f}% tax.");
        }
    }
}
