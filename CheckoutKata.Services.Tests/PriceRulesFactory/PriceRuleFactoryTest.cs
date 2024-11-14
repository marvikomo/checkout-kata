using System;
using CheckoutKata.Services.Model;
using CheckoutKata.Services.PricingRules;
using CheckoutKata.Services.Factories;


namespace CheckoutKata.Services.Tests.PriceRulesFactory
{
    public class PriceRuleFactoryTest
    {
        [Fact]
        public void Create_WithSimplePricingRule_ShouldReturnSimplePricer()
        {
            // Arrange
            var rules = new[] { new PricingRule("A", 50) };

            // Act
            var priceRules = PriceRuleFactory.CreatePricingRules(rules);

            // Assert
            Assert.Single(priceRules);
            Assert.IsType<SimplePriceRule>(priceRules["A"]);
            Assert.Equal(50, priceRules["A"].CalculateTotal(1));
        }

        [Fact]
        public void Create_WithSpecialOffer_ShouldReturnSpecialPricer()
        {
            var rules = new[] {
            new PricingRule("A", 50, new SpecialOffer(3, 130))
            };

            var pricerRules = PriceRuleFactory.CreatePricingRules(rules);

            Assert.Single(pricerRules);
            Assert.IsType<SpecialPriceRule>(pricerRules["A"]);
            Assert.Equal(130, pricerRules["A"].CalculateTotal(3));
        }

        [Fact]
        public void Create_WithMixedRules_ShouldReturnCorrectPricers()
        {
            var rules = new[] {
            new PricingRule("A", 50, new SpecialOffer(3, 130)),
            new PricingRule("B", 30),
            new PricingRule("C", 20)
            };

            var pricingRules = PriceRuleFactory.CreatePricingRules(rules);

            Assert.Equal(3, pricingRules.Count);
            Assert.IsType<SpecialPriceRule>(pricingRules["A"]);
            Assert.IsType<SimplePriceRule>(pricingRules["B"]);
            Assert.IsType<SimplePriceRule>(pricingRules["C"]);

            // Verify calculations
            Assert.Equal(130, pricingRules["A"].CalculateTotal(3));  // Special price for A
            Assert.Equal(60, pricingRules["B"].CalculateTotal(2));   // Normal price for B
            Assert.Equal(40, pricingRules["C"].CalculateTotal(2));   // Special price for C
        }

        [Fact]
        public void Create_WithNullRules_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => PriceRuleFactory.CreatePricingRules(null));
        }

        [Fact]
        public void Create_WithEmptyRules_ShouldReturnEmptyCollection()
        {
            var pricers = PriceRuleFactory.CreatePricingRules(Enumerable.Empty<PricingRule>());
            Assert.Empty(pricers);
        }

    }
}