using Price_Calculator_Kata.Cap;
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
        public string currency { get; set; }
        public ITax tax { get; set; }
        public List<IDiscount> discounts { get; set; }
        public List<IExpense> expenses { get; set; }
        public ICap cap { get; set; }
        public MultiplicativeProductPriceCalculatorWithTaxDiscountsAndExpenses productPriceCalculatorWithTaxDiscountsAndExpenses { get; set; }

        public ProductWithTaxDiscountsAndExpensesPrinter(IProduct product, string currency, ITax tax, 
            List<IDiscount> discounts, ICap cap, List<IExpense> expenses)
        {
            this.product = product;
            this.tax = tax;
            this.discounts = discounts;
            this.expenses = expenses;
            this.cap = cap; 
            productPriceCalculatorWithTaxDiscountsAndExpenses = new
                MultiplicativeProductPriceCalculatorWithTaxDiscountsAndExpenses(product, tax, discounts, cap, expenses);
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

            Console.WriteLine($"Total: {totalPrice}");

        }
    }


}
