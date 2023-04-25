using Price_Calculator_Kata.Discount;
using Price_Calculator_Kata.Expenses;
using Price_Calculator_Kata.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPriceCalculator
{
    public class MultiplicativeProductPriceCalculatorWithTaxDiscountsAndExpenses :
        MultiplicativeProductPriceCalculatorWithTaxAndDiscounts, IProductPriceCalculatorWithExpenses
    {

        public List<IExpense> expenses { get; set; }
        public float totalExpensesAmount { get; set; }

        public MultiplicativeProductPriceCalculatorWithTaxDiscountsAndExpenses(IProduct product, ITax tax, List<IDiscount> discounts, List<IExpense> expenses) : base(product, tax, discounts)
        {
            this.expenses = expenses;
        }

        public float CalculatePrice()
        {
            float price = base.CalculatePrice();

            foreach (var expense in expenses)
            {
                totalExpensesAmount += expense.GetExpense(product.price);
                totalExpensesAmount = totalExpensesAmount.Round(2);
            }

            return (price + totalExpensesAmount).Round(2);
        }
    }
}
