using System;
using CheckoutKata.Services.Interfaces;


namespace CheckoutKata.Services.PricingRules
{
    public class SpecialPriceRule : IPricingRule
    {
        private readonly int unitPrice;
        private readonly int specialQuantity;
        private readonly int specialPrice;
        public string Item { get; }
        public SpecialPriceRule(string item, int unitPrice, int specialQuantity, int specialPrice)
        {
            Item = item;
            this.unitPrice = unitPrice;
            this.specialQuantity = specialQuantity;
            this.specialPrice = specialPrice;
        }
        public int CalculateTotal(int quantity)
        {
            var specialDeals = quantity / specialQuantity;
            var remainder = quantity % specialQuantity;
            return (specialDeals * specialPrice) + (remainder * unitPrice);
        }
    }
}