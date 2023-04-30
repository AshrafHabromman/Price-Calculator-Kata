using Price_Calculator_Kata.Cap;
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
    public class AdditiveProductPriceCalculatorWithTaxDiscountsAndExpenses : AdditiveProductPriceCalculatorWithTaxAndDiscounts,  IProductPriceCalculatorWithExpenses
    {

        public List<IExpense> expenses { get; set; }
        public float totalExpensesAmount { get; set; }

        public AdditiveProductPriceCalculatorWithTaxDiscountsAndExpenses(IProduct product, string currency, ITax tax, List<IDiscount> discounts, ICap cap, List<IExpense> expenses, int precision) : base(product, currency, tax, discounts, cap, precision)
        {
            this.expenses= expenses;   
        }
            
        public float CalculatePrice()
        {
            float price = base.CalculatePrice();
            
            foreach(var expense in expenses)
            {
                totalExpensesAmount += expense.GetExpense(product.price).Round(precision);
                totalExpensesAmount = totalExpensesAmount.Round(precision);
            }
            
            return (price + totalExpensesAmount).Round(precision);
        }
    }
}
