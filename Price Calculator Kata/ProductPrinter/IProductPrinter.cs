using Price_Calculator_Kata.Product;
using Price_Calculator_Kata.ProductPriceCalculator;

namespace Price_Calculator_Kata.ProductPrinter
{
    public interface IProductPrinter
    {
        IProduct product { get; set; }
        public string currency { get; set; }
        public int printingPrecision { get; set; }
        void PrintPrice();
    }
}