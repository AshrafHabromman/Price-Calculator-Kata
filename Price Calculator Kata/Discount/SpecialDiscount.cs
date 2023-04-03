using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Discount
{
    public class SpecialDiscount : Discount
    {
        public float upcDiscountPercentage  {get; set;}
        public SpecialDiscount(float disconutPercentage, float upcDiscountPercentage) : base(disconutPercentage)
        {
            this.upcDiscountPercentage = upcDiscountPercentage;
        }

        public override float CalculateDiscount(float price)
        { 
            float discount = base.CalculateDiscount(price);
            float specialDiscount = price * upcDiscountPercentage;
  
            return discount + specialDiscount;
        
        }
    }
}
