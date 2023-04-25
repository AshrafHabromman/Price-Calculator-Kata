using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Expenses
{
    public class AmountExpense : IExpense
    {
        public string description { get; set; }
        public float expenseAmount { get; set; }
        public AmountExpense(string description, float expenseAmount) 
        {
            this.description = description;
            this.expenseAmount = expenseAmount;
        }

        public float GetExpense(float price)
        {
            return expenseAmount.Round(2);
        }

    }
}
