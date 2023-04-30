using Price_Calculator_Kata.Cap;
using Price_Calculator_Kata.Discount;
using Price_Calculator_Kata.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPriceCalculator
{
    public class AdditiveProductPriceCalculatorWithTaxAndDiscounts : IProductPriceCalculatorWithTax, 
        IProductPriceCalculatorWithDiscounts
    {
        public IProduct product { get; set; }
        public string currency { get; set; }
        public int precision { get; set; }
        public ITax tax { get; set; }
        public List<IDiscount> discounts { get; set; }
        public float totalDiscountAmount { get; set; }
        public ICap cap { get; set; }
        public AdditiveProductPriceCalculatorWithTaxAndDiscounts(IProduct product, string currency, ITax tax, List<IDiscount> discounts, ICap cap, int precision)
        {
            this.product = product;
            this.currency = currency;
            this.tax = tax;
            this.discounts = discounts;
            this.totalDiscountAmount = 0;
            this.cap = cap;
            this.precision = precision;
        }

        public float CalculateDiscounts(float price, bool isBefore)
        {
            float discountsAmount = 0;
            for (int i = 0; i < discounts.Count; i++)
            {
                if (discounts[i] is SpecialUPCDiscount)
                    if (!((SpecialUPCDiscount)discounts[i]).IsDiscountable(product.UPC))
                        continue;
                if (discounts[i].isBeforeTax == isBefore)
                {
                    discountsAmount += discounts[i].CalculateDiscount(price).Round(precision);
                }
            }
            return discountsAmount.Round(precision);
        }
        public float CalculatePrice()
        {
            float discountsBeforeTax = CalculateDiscounts(product.price, true);
            this.totalDiscountAmount += discountsBeforeTax;
            float price = (product.price - discountsBeforeTax).Round(precision);
            float taxAmount = tax.CalculateTax(price).Round(precision);

            float discountsAfterTax = CalculateDiscounts(price, false);
            this.totalDiscountAmount += discountsAfterTax;

            this.totalDiscountAmount = this.totalDiscountAmount.Round(precision);

            float finalDiscount = cap.GetFinalDiscountAmount(this.totalDiscountAmount, product.price).Round(precision);
            this.totalDiscountAmount = finalDiscount;
            float finalPrice = price + taxAmount - finalDiscount;
            return finalPrice.Round(precision);
        }
    }
}
