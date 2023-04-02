

// See https://aka.ms/new-console-template for more information
using Price_Calculator_Kata;
using Price_Calculator_Kata.Product;
using Price_Calculator_Kata.ProductPrinter;
using Price_Calculator_Kata.Tax;

Console.Write("Please enter the tax percentage you would like: ");
double taxPercentage = Convert.ToDouble(Console.ReadLine());
Console.Write("Please enter the discount percentage you would like: ");
double discountPercentage = Convert.ToDouble(Console.ReadLine());

ITax taxCalculator = new TaxCalculator((float)taxPercentage);
IDiscount discount = new Discount((float)discountPercentage);
IProduct product = new Product("Potato", 1234, 20.25f);

IProductPrinter productPrinter = new ProductPrinterWithTaxAndDiscount(product, taxCalculator, discount);

productPrinter.PrintPrice();

