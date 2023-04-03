using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Discount
{
    public class Discount : IDiscount
    {
        public float discountPercentage { get; set; }
        public Discount(float disconutPercentage)
        {
            discountPercentage = disconutPercentage;
        }
        public virtual float CalculateDiscount(float price)
        {
            return discountPercentage * price;
        }
    }
}
