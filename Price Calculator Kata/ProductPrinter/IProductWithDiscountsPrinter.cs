using Price_Calculator_Kata.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPrinter
{
    public interface IProductWithDiscountsPrinter : IProductPrinter
    {
        public List<IDiscount> discounts { get; set; }

    }
}
