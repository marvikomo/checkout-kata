using System;
using CheckoutKata.Services.Interfaces;


namespace CheckoutKata.Services.PricingRules
{
    public class SpecialPriceRule : IPricingRule
    {
        public string Item { get; }
        public SpecialPriceRule(string item, int unitPrice, int specialQuantity, int specialPrice)
        {
          Item = item;
        }
        public int CalculateTotal(int quantity)
        {
            throw new NotImplementedException();
        }
    }
}