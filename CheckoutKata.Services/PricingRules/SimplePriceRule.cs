using System;
using CheckoutKata.Services.Interfaces;


namespace CheckoutKata.Services.PricingRules
{
    public class SimplePriceRule : IPricingRule
    {
        private readonly int unitPrice;
        public string Item { get; }
        public SimplePriceRule(string item, int unitPrice)
        {
           Item = item;
           this.unitPrice = unitPrice;
        }
        public int CalculateTotal(int quantity)
        {
           return quantity * unitPrice;
        }
    }
}