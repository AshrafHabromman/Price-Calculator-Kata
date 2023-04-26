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
    public class MultiplicativeProductPriceCalculatorWithTaxAndDiscounts : IProductPriceCalculatorWithTax,
        IProductPriceCalculatorWithDiscounts
    {
        public IProduct product { get; set; }
        public ITax tax { get; set; }
        public List<IDiscount> discounts { get; set; }
        public float totalDiscountAmount { get; set; }

        public ICap cap { get; set; }

        public MultiplicativeProductPriceCalculatorWithTaxAndDiscounts(IProduct product, ITax tax, List<IDiscount> discounts, ICap cap)
        {
            this.product = product;
            this.tax = tax;
            this.discounts = discounts;
            this.totalDiscountAmount = 0;
            this.cap = cap;
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

            float finalDiscount = cap.GetFinalDiscountAmount(this.totalDiscountAmount, product.price);
            this.totalDiscountAmount = finalDiscount;
            float finalPrice = price + taxAmount - finalDiscount;
            return finalPrice.Round(2);
        }
    }
}