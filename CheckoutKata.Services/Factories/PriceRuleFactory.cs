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
        public static IEnumerable<IPricingRule> Create(IEnumerable<PricingRule> rules)
        {
            return rules.Select(rule => new SimplePriceRule(rule.Item, rule.UnitPrice));
        }
    }
}