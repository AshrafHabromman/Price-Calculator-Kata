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
    public class ProductWithTaxAndDiscountsPrinter : IProductWithTaxPrinter, IProductWithDiscountsPrinter
    {
        public IProduct product { get; set; }
        public ITax tax { get; set; }
        public List<IDiscount> discounts { get; set; }

        public AdditiveProductPriceCalculatorWithTaxAndDiscounts productPriceCalculatorWithTaxAndDiscounts { get; set; }

        public ProductWithTaxAndDiscountsPrinter(IProduct product, ITax tax, List<IDiscount> discounts)
        {
            this.product =  product; 
            this.tax = tax;
            this.discounts = discounts;

            productPriceCalculatorWithTaxAndDiscounts = 
                new AdditiveProductPriceCalculatorWithTaxAndDiscounts(product, tax, discounts);
        }
        public void PrintPrice()
        {
            float price = product.price;

            float totalPrice = productPriceCalculatorWithTaxAndDiscounts.CalculatePrice();

            Console.Write($"Price before = {price :#.##}, Price after = {totalPrice:#.##}\n");
            Console.Write($"Total discount amount : {productPriceCalculatorWithTaxAndDiscounts.totalDiscountAmount}");

        }
    }
}
