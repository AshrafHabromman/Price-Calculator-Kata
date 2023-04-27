using Price_Calculator_Kata.Product;
using Price_Calculator_Kata.ProductPriceCalculator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPrinter
{
    public class ProductWithTaxPrinter : IProductWithTaxPrinter
    {
        public IProduct product { get; set; }
        public string currency { get; set; }
        public ITax tax { get; set; }
        public IProductPriceCalculatorWithTax productPriceCalculatorWithTax { get; set; }

        public ProductWithTaxPrinter(IProduct product, string currency, ITax tax)
        {
            this.product  = product;
            this.currency= currency;
            this.tax = tax;

            this.productPriceCalculatorWithTax = new ProductPriceCalculatorWithTax(product, currency, tax);
        }

        public void PrintPrice()
        {

            float totalPrice = productPriceCalculatorWithTax.CalculatePrice();

            Console.WriteLine($"Cost = {product.price:#.##} {this.currency}");
            Console.WriteLine($"Tax = {tax.taxAmount} {this.currency}");
            Console.WriteLine($"Total: {totalPrice} {this.currency}");

        }
    }
}
