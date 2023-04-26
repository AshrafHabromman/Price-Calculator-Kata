using Price_Calculator_Kata.Cap;
using Price_Calculator_Kata.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPriceCalculator
{
    public interface IProductPriceCalculatorWithDiscounts : IProductPriceCalculator
    {
        public List<IDiscount> discounts { get; set; }
        public float totalDiscountAmount { get; set; }
        public ICap cap { get; set; }
    }
}
