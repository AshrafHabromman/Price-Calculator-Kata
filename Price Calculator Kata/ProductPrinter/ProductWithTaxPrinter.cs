using Price_Calculator_Kata.Product;
using Price_Calculator_Kata.ProductPriceCalculator;
using System;
using System.Collections.Generic;
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

            float finalPrice = productPriceCalculatorWithTax.CalculatePrice();

            Console.WriteLine($"Product price reported as ${productPriceCalculatorWithTax.product.price:#.##} {this.currency} before tax " +
                $"and ${finalPrice:#.##} {this.currency} after {tax.taxPercentage * 100f}% tax.");
        }
    }
}
