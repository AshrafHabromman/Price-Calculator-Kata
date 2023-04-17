using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Discount
{
    public interface IDiscount
    {
        float discountPercentage { get; set; }
        bool isBeforeTax { get; set; }
        public float CalculateDiscount(float price);
    }
}
