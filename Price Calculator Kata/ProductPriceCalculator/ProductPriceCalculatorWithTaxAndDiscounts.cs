using Price_Calculator_Kata.Discount;
using Price_Calculator_Kata.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ProductPriceCalculator
{
    public class ProductPriceCalculatorWithTaxAndDiscounts : IProductPriceCalculatorWithTax, IProductPriceCalculatorWithDiscounts
    {
        public IProduct product { get; set; }
        public ITax tax { get; set; }
        public List<IDiscount> discounts { get; set; }

        public ProductPriceCalculatorWithTaxAndDiscounts(IProduct product, ITax tax, List<IDiscount> discounts)
        {
            this.product = product;
            this.tax = tax;
            this.discounts = discounts;
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
                    discountsAmount += discounts[i].CalculateDiscount(product.price);
                }
            }
            return discountsAmount;
        }
        public float CalculatePrice()
        {
            float discountsBeforeTax = CalculateDiscounts(product.price, true);

            float price = product.price - discountsBeforeTax;
            float taxAmount = tax.CalculateTax(price);

            float discountsAfterTax = CalculateDiscounts(price, false);

            return price + taxAmount - discountsAfterTax;
        }
    }
}
