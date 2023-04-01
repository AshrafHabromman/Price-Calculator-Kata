

// See https://aka.ms/new-console-template for more information
using Price_Calculator_Kata;
using Price_Calculator_Kata.Product;
using Price_Calculator_Kata.Tax;

Console.Write("Please input the tax percentage you would like: ");

double taxPercentage = Convert.ToDouble(Console.ReadLine());
ITax taxCalculator = new TaxCalculator((float)taxPercentage);
IProduct product = new Product("Potato", 1234, 20.25f);

IProductPrinter productPrinter = new ProductPrinterWithTax(product, taxCalculator);

productPrinter.PrintPrice();

