using Price_Calculator_Kata.Product;

namespace Price_Calculator_Kata.ProductPrinter
{
    public interface IProductPrinter
    {
        IProduct product { get; set; }
        void PrintPrice();
    }
}