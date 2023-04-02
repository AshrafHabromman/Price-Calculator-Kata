using Price_Calculator_Kata.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPrinter
{
    public class ProductPrinterWithTaxAndDiscount : IProductPrinter
    {
        public IProduct product { get; set; }
        public ITax tax { get; set; }
        public IDiscount discount { get; set; }

        public ProductPrinterWithTaxAndDiscount(IProduct product, ITax tax, IDiscount discount)
        {
            this.product =  product; 
            this.tax = tax;
            this.discount = discount;
        }
        public void PrintPrice()
        {
            float price = product.price;
            float taxAmount = tax.CalculateTax(price);
            float discountAmount = discount.CalculateDiscount(price);

            float totalPrice = price + taxAmount - discountAmount;

            Console.WriteLine($"Tax = {tax.taxPercentage * 100}% discount = {discount.discountPercentage * 100:#.##}%" +
                $" Tax Amount = {taxAmount:#.##} Discount Amount {discountAmount:#.##}");
            Console.Write($"Price before = {price :#.##}, Price after = {totalPrice:#.##}");

        }
    }
}
