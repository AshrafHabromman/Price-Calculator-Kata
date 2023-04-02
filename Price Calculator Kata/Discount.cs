using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class Discount: IDiscount
    {
        public float discountPercentage { get; set; }
        public Discount(float disconutPercentage) 
        {
            this.discountPercentage = disconutPercentage;
        }
        public float CalculateDiscount(float price)
        {
            return discountPercentage * price;
        }
    }
}
