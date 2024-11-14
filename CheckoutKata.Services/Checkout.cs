using System;
using CheckoutKata.Services.Factories;
using CheckoutKata.Services.Interfaces;
using CheckoutKata.Services.Model;

namespace CheckoutKata.Services
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, IPricingRule> pricingRules;
        private readonly Dictionary<string, int> scannedItems;

        public Checkout(IEnumerable<PricingRule> rules)
        {
            if (rules == null)
                throw new ArgumentNullException(nameof(rules));

            pricingRules = PriceRuleFactory.CreatePricingRules(rules);
            scannedItems = new Dictionary<string, int>();

        }

        public void Scan(string item)
        {
            if (!pricingRules.ContainsKey(item))
                throw new ArgumentException($"Invalid item: {item}");

            if (!scannedItems.ContainsKey(item))
                scannedItems[item] = 0;

            scannedItems[item]++;

        }

        public int GetTotalPrice()
        {
            return scannedItems.Sum(item =>
              pricingRules[item.Key].CalculateTotal(item.Value));
        }
    }
}