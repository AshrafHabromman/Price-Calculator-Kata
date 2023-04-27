using Price_Calculator_Kata.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPriceCalculator
{
    public class ProductPriceCalculatorWithTax: IProductPriceCalculatorWithTax
    {
        public IProduct product { get; set; }
        public string currency { get; set; }
        public ITax tax { get; set; }

        public ProductPriceCalculatorWithTax(IProduct product, string currency, ITax tax)
        {
            this.product = product;
            this.currency = currency;
            this.tax = tax;
        }

        public float CalculatePrice()
        {
            float price = product.price; 
            return tax.CalculateTax(price) + price;
        }
    }
}
