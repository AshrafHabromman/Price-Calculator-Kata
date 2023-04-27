using Price_Calculator_Kata.Discount;
using Price_Calculator_Kata.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPriceCalculator
{
    public interface IProductPriceCalculatorWithExpenses : IProductPriceCalculator
    {
        public List<IExpense> expenses { get; set; }
        public float totalExpensesAmount { get; set; }
    }
}
