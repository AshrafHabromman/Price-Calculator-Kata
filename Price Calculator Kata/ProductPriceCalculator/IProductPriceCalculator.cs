using Price_Calculator_Kata.Discount;
using Price_Calculator_Kata.Product;

namespace Price_Calculator_Kata.ProductPriceCalculator
{
    public interface IProductPriceCalculator
    {
        public IProduct product { get; set; }
        public string currency { get; set; }
        public int precision { get; set; }
        public float CalculatePrice();

    }
}

