using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Cap
{
    public class PercentageCap: ICap
    {
        public float capPercentage { get; set; }

        public PercentageCap(float capPercentage)
        {
            this.capPercentage = capPercentage;
        }

        public float GetFinalDiscountAmount(float discount, float price)
        {
            float capAmount = price * capPercentage;
            Console.WriteLine(discount);
            if (discount >= capAmount)
            {
                Console.WriteLine(capAmount);
                return capAmount;
            }
            Console.WriteLine($"Hii {capAmount}");
            return discount;
        }
    }
}
