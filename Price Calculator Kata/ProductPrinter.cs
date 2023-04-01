using Price_Calculator_Kata.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class ProductPrinterWithTax : IProductPrinter
    {
        public IProduct product { get; set; }
        public ITax tax { get; set; }

        public ProductPrinterWithTax(IProduct product, ITax tax)
        {
            this.product = product;
            this.tax = tax;
        }

        public void PrintPrice()
        {
            float price = product.price;
            float totalPrice = tax.CalculateTax(price) + price;

            Console.Write($"Product price reported as ${price:#.##} before tax " +
                $"and ${totalPrice:#.##} after {tax.taxPercentage * 100f}% tax.");
        }
    }
}
