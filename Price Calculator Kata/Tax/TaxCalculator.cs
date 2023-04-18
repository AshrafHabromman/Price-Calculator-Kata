
namespace Price_Calculator_Kata.Tax
{
    public class TaxCalculator: ITax
    {
        public float taxPercentage { get; set; }

        public TaxCalculator(float taxPercentage)
        {
            this.taxPercentage = taxPercentage;
        }

        public float CalculateTax(float price) 
        {
            float taxAmount = this.taxPercentage * price;
            return taxAmount.Round(2);
        }  
    }
}
