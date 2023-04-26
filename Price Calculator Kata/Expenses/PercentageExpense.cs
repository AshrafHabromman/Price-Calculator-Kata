using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Expenses
{
    public class PercentageExpense : IExpense
    {
        public string description { get; set; }
        public float expensePercentage { get; set; }
        
        public PercentageExpense(string description, float expensePercentage)
        {
            this.description = description;
            this.expensePercentage = expensePercentage;
        }

        public float GetExpense(float price)
        {
            return (expensePercentage * price).Round(2);
        }
    }
}
