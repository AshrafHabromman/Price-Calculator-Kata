

namespace Price_Calculator_Kata.ProductPriceCalculator
{
    public interface IProductPriceCalculatorWithTax : IProductPriceCalculator
    {
        public ITax tax { get; set; }

    }
}
