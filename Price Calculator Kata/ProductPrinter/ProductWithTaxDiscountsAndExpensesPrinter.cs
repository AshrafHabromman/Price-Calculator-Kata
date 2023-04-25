using Price_Calculator_Kata.Discount;
using Price_Calculator_Kata.Expenses;
using Price_Calculator_Kata.Product;
using Price_Calculator_Kata.ProductPriceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPrinter
{
    public class ProductWithTaxDiscountsAndExpensesPrinter : IProductWithTaxPrinter, 
        IProductWithDiscountsPrinter, IProductWithExpensesPrinter
    {
        public IProduct product { get; set; }
        public ITax tax { get; set; }
        public List<IDiscount> discounts { get; set; }
        public List<IExpense> expenses { get; set; }

        public ProductPriceCalculatorWithTaxDiscountsAndExpenses productPriceCalculatorWithTaxDiscountsAndExpenses { get; set; }

        public ProductWithTaxDiscountsAndExpensesPrinter(IProduct product, ITax tax, 
            List<IDiscount> discounts, List<IExpense> expenses)
        {
            this.product = product;
            this.tax = tax;
            this.discounts = discounts;
            this.expenses = expenses;

            productPriceCalculatorWithTaxDiscountsAndExpenses = new
                ProductPriceCalculatorWithTaxDiscountsAndExpenses(product, tax, discounts, expenses);
        }

        public void PrintPrice()
        {
            float price = product.price;

            float totalPrice = productPriceCalculatorWithTaxDiscountsAndExpenses.CalculatePrice();

            Console.WriteLine($"Cost = {price:#.##}");
            Console.WriteLine($"Tax = {tax.taxAmount}");
            Console.WriteLine($"Discounts = {productPriceCalculatorWithTaxDiscountsAndExpenses.totalDiscountAmount}");
            foreach(var expense in expenses)
            {
                Console.WriteLine($"{expense.description} cost = {expense.GetExpense(price)}");
            }

            Console.Write($"Total: {totalPrice}");

        }
    }


}
