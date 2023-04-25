using Price_Calculator_Kata.Discount;
using Price_Calculator_Kata.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPriceCalculator
{
    public class MultiplicativeProductPriceCalculatorWithTaxAndDiscounts : IProductPriceCalculatorWithTax,
        IProductPriceCalculatorWithDiscounts
    {
        public IProduct product { get; set; }
        public ITax tax { get; set; }
        public List<IDiscount> discounts { get; set; }
        public float totalDiscountAmount { get; set; }

        public MultiplicativeProductPriceCalculatorWithTaxAndDiscounts(IProduct product, ITax tax, List<IDiscount> discounts)
        {
            this.product = product;
            this.tax = tax;
            this.discounts = discounts;
            this.totalDiscountAmount = 0;
        }

        public float CalculateDiscounts(float price, bool isBefore)
        {
            float discountsAmount = 0;
            float usedPrice = price;
            for (int i = 0; i < discounts.Count; i++)
            {
                if (discounts[i] is SpecialUPCDiscount)
                    if (!((SpecialUPCDiscount)discounts[i]).IsDiscountable(product.UPC))
                        continue;
                if (discounts[i].isBeforeTax == isBefore)
                {
                    float discount = discounts[i].CalculateDiscount(usedPrice);
                    usedPrice -= discount;
                    discountsAmount += discount;
                }
            }
            return discountsAmount.Round(2);
        }
        public float CalculatePrice()
        {
            float discountsBeforeTax = CalculateDiscounts(product.price, true);
            this.totalDiscountAmount += discountsBeforeTax;
            float price = (product.price - discountsBeforeTax).Round(2);
            float taxAmount = tax.CalculateTax(price);

            float discountsAfterTax = CalculateDiscounts(price, false);
            this.totalDiscountAmount += discountsAfterTax;
            float finalPrice = price + taxAmount - discountsAfterTax;
            return finalPrice.Round(2);
        }
    }
}