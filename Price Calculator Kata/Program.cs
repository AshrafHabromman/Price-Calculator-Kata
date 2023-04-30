

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

IExpense transport = new PercentageExpense("Transport", 0.03f);
List<IExpense> expenses = new List<IExpense>
{
    transport
};


IProductPrinter productPrinter = new
    ProductWithTaxDiscountsAndExpensesPrinter(product, "USD",
    taxCalculator, discounts, new AmountCap(10f)
    , expenses, 4, 2);

productPrinter.PrintPrice();

Console.WriteLine();
