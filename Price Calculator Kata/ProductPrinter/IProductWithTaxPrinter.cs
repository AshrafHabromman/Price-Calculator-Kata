using Price_Calculator_Kata.ProductPriceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPrinter
{
    public interface IProductWithTaxPrinter: IProductPrinter
    {
        public ITax tax { get; set; }

    }
}
