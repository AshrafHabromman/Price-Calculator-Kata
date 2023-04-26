

// See https://aka.ms/new-console-template for more information
using Price_Calculator_Kata;
using Price_Calculator_Kata.Cap;
using Price_Calculator_Kata.Discount;
using Price_Calculator_Kata.Expenses;
using Price_Calculator_Kata.Product;
using Price_Calculator_Kata.ProductPrinter;
using Price_Calculator_Kata.Tax;

Console.Write("Please enter the tax percentage you would like: ");
double taxPercentage = Convert.ToDouble(Console.ReadLine());
Console.Write("Please enter the discount percentage you would like: ");
double discountPercentage = Convert.ToDouble(Console.ReadLine());

ITax taxCalculator = new TaxCalculator((float)taxPercentage);

float upcDiscount = 0.07f;
IDiscount discount = new Discount((float)discountPercentage, false);
IDiscount specialUPCDiscount = new SpecialUPCDiscount(1234, (float)upcDiscount, false);

IProduct product = new Product("Potato", 1234, 20.25f);

List<IDiscount> discounts = new List<IDiscount>
{
    discount,
    specialUPCDiscount
};

IExpense packaging = new PercentageExpense("Packaging", 0.01f);
IExpense transport = new AmountExpense("Transport", 2.2f);
List<IExpense> expenses = new List<IExpense>
{
    packaging,
    transport
};

ICap percentageCap = new PercentageCap(0.20f);

IProductPrinter productPrinter = new
    ProductWithTaxAndDiscountsPrinter(product,
    taxCalculator, discounts, percentageCap);

productPrinter.PrintPrice();

Console.WriteLine();

ICap amountCap = new AmountCap(4.0f);

IProductPrinter productPrinter1 = new
    ProductWithTaxAndDiscountsPrinter(product,
    taxCalculator, discounts, amountCap);

productPrinter1.PrintPrice();

Console.WriteLine();

((PercentageCap)percentageCap).capPercentage = 0.30f;

IProductPrinter productPrinter2 = new
    ProductWithTaxAndDiscountsPrinter(product,
    taxCalculator, discounts, percentageCap);

productPrinter2.PrintPrice();