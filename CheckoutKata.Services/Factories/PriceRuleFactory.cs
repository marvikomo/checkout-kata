using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutKata.Services.Interfaces;
using CheckoutKata.Services.Model;
using CheckoutKata.Services.PricingRules;

namespace CheckoutKata.Services.Factories
{
    public static class PriceRuleFactory
    {

        public static Dictionary<string, IPricingRule> CreatePricingRules(IEnumerable<PricingRule> rules)
        {
            if (rules == null)
                throw new ArgumentNullException(nameof(rules));

            return rules.ToDictionary(
                rule => rule.Item,
                rule => CreateRule(rule)
            );
        }

        private static IPricingRule CreateRule(PricingRule rule)
        {
            return rule.Special != null
                ? new SpecialPriceRule(rule.Item, rule.UnitPrice, rule.Special.Quantity, rule.Special.SpecialPrice)
                : new SimplePriceRule(rule.Item, rule.UnitPrice);
        }
    }
}