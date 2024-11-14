using System;
using CheckoutKata.Services.Interfaces;


namespace CheckoutKata.Services.PricingRules
{
    public class SimplePriceRule : IPricingRule
    {
        public int CalculateTotal(int quantity)
        {
            throw new NotImplementedException();
        }
    }
}