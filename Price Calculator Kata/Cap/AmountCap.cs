using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Cap
{
    public class AmountCap : ICap
    {
        public float capAmount { get; set; }

        public AmountCap(float capAmount)
        {
            this.capAmount = capAmount;
        }

        public float GetFinalDiscountAmount(float discount, float price)
        {
            if (discount >= capAmount) 
            {
                return capAmount;
            }
            return discount;
        }
    }
}
