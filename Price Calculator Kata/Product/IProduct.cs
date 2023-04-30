namespace Price_Calculator_Kata.Product
{
    public interface IProduct
    {
        string name { get; set; }
        float price { get; set; }
        int UPC { get; set; }
    }
}