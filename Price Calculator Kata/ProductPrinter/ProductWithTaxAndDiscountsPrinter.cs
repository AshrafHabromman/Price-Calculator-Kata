using Price_Calculator_Kata.Cap;
using Price_Calculator_Kata.Discount;
using Price_Calculator_Kata.Product;
using Price_Calculator_Kata.ProductPriceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPrinter
{
    public class ProductWithTaxAndDiscountsPrinter : IProductWithTaxPrinter,
        IProductWithDiscountsPrinter
    {
        public IProduct product { get; set; }
        public string currency { get; set; }
        public ITax tax { get; set; }
        public List<IDiscount> discounts { get; set; }
        public ICap cap { get; set; }
        public AdditiveProductPriceCalculatorWithTaxAndDiscounts productPriceCalculatorWithTaxAndDiscounts { get; set; }

        public ProductWithTaxAndDiscountsPrinter(IProduct product, string currency, ITax tax, List<IDiscount> discounts, ICap cap)
        {
            this.product =  product;
            this.currency = currency;
            this.tax = tax;
            this.discounts = discounts;
            this.cap = cap; 
            productPriceCalculatorWithTaxAndDiscounts = 
                new AdditiveProductPriceCalculatorWithTaxAndDiscounts(product,currency, tax, discounts, cap);
        }
        public void PrintPrice()
        {
            float price = product.price;

            float totalPrice = productPriceCalculatorWithTaxAndDiscounts.CalculatePrice();

            Console.WriteLine($"Cost = {price:#.##} {this.currency}");
            Console.WriteLine($"Tax = {tax.taxAmount} {this.currency}");
            Console.WriteLine($"Discounts = {productPriceCalculatorWithTaxAndDiscounts.totalDiscountAmount} {this.currency}");
            Console.WriteLine($"Total: {totalPrice} {this.currency}");
        }
    }
}
