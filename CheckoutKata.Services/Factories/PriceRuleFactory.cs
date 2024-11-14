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
            if (rules == null)
                throw new ArgumentNullException(nameof(rules));

            return rules.Select<PricingRule, IPricingRule>(rule =>
                rule.Special != null
                    ? new SpecialPriceRule(rule.Item, rule.UnitPrice, rule.Special.Quantity, rule.Special.SpecialPrice)
                    : new SimplePriceRule(rule.Item, rule.UnitPrice)
            );
        }
    }
}