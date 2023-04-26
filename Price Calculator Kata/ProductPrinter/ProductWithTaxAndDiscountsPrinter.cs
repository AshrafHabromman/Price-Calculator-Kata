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
        public ITax tax { get; set; }
        public List<IDiscount> discounts { get; set; }
        public ICap cap { get; set; }
        public AdditiveProductPriceCalculatorWithTaxAndDiscounts productPriceCalculatorWithTaxAndDiscounts { get; set; }

        public ProductWithTaxAndDiscountsPrinter(IProduct product, ITax tax, List<IDiscount> discounts, ICap cap)
        {
            this.product =  product; 
            this.tax = tax;
            this.discounts = discounts;
            this.cap = cap; 
            productPriceCalculatorWithTaxAndDiscounts = 
                new AdditiveProductPriceCalculatorWithTaxAndDiscounts(product, tax, discounts, cap);
        }
        public void PrintPrice()
        {
            float price = product.price;

            float totalPrice = productPriceCalculatorWithTaxAndDiscounts.CalculatePrice();

            Console.WriteLine($"Cost = {price:#.##}");
            Console.WriteLine($"Tax = {tax.taxAmount}");
            Console.WriteLine($"Discounts = {productPriceCalculatorWithTaxAndDiscounts.totalDiscountAmount}");
            Console.WriteLine($"Total: {totalPrice}");
        }
    }
}
