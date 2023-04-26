using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Expenses
{
    public interface IExpense
    {
        public string description { get; set; }
        public float GetExpense(float price);
    }
}
