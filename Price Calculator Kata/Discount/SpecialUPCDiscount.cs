using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Discount
{
    public class SpecialUPCDiscount : IDiscount
    {
        public float discountPercentage  {get; set;}
        public bool isBeforeTax { get; set; }
        public int upc { get; set;  }
        public SpecialUPCDiscount(int upc, float upcDiscountPercentage, bool isBeforeTax )
        {
            this.upc = upc;
            this.discountPercentage = upcDiscountPercentage;
            this.isBeforeTax = isBeforeTax;
        }

        public float CalculateDiscount(float price)
        { 
            return price * discountPercentage;
        }

        public bool IsDiscountable(int upc) 
        {
            return upc == this.upc;
        }
    }
}
