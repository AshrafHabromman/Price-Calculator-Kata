using Price_Calculator_Kata.Discount;
using Price_Calculator_Kata.Product;

namespace Price_Calculator_Kata.ProductPriceCalculator
{
    public interface IProductPriceCalculator
    {
        IProduct product { get; set; }

        public float CalculatePrice();

    }
}

