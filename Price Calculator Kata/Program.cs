// See https://aka.ms/new-console-template for more information
using Price_Calculator_Kata;

Console.WriteLine("Hello, World!");
Product p = new Product("lol", 1234, 25.2356f);

Product.taxPercentage = 0.2f;
ProductPrinter productPrinter = new ProductPrinter(p);
productPrinter.PrintPrice();

