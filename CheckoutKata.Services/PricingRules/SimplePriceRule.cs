using System;
using CheckoutKata.Services.Interfaces;


namespace CheckoutKata.Services.PricingRules
{
    public class SimplePriceRule : IPricingRule
    {
        public string Item { get; }
        public SimplePriceRule(string item, int unitPrice)
        {
           Item = item;
        }
        public int CalculateTotal(int quantity)
        {
            throw new NotImplementedException();
        }
    }
}