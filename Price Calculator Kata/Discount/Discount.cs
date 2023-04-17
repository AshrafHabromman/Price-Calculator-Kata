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
        public bool isBeforeTax { get; set; }
        public Discount(float disconutPercentage, bool isBeforeTax)
        {
            this.discountPercentage = disconutPercentage;
            this.isBeforeTax = isBeforeTax;
        }
        public virtual float CalculateDiscount(float price)
        {
            return discountPercentage * price;
        }
    }
}
