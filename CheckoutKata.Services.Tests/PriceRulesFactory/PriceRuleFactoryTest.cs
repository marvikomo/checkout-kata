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
            var priceRules = PriceRuleFactory.Create(rules);

            // Assert
            var priceRule = priceRules.Single();
            Assert.IsType<SimplePriceRule>(priceRule);
            Assert.Equal("A", priceRule.Item);
            Assert.Equal(50, priceRule.CalculateTotal(1));
        }

        [Fact]
        public void Create_WithSpecialOffer_ShouldReturnSpecialPricer()
        {
            var rules = new[] {
            new PricingRule("A", 50, new SpecialOffer(3, 130))
            };

            var pricerRules = PriceRuleFactory.Create(rules);

            var pricerRule = pricerRules.Single();
            Assert.IsType<SpecialPriceRule>(pricerRule);
            Assert.Equal("A", pricerRule.Item);
            Assert.Equal(130, pricerRule.CalculateTotal(3));
        }

        [Fact]
        public void Create_WithMixedRules_ShouldReturnCorrectPricers()
        {
            var rules = new[] {
            new PricingRule("A", 50, new SpecialOffer(3, 130)),
            new PricingRule("B", 30),
            new PricingRule("C", 20)
            };

            var pricingRules = PriceRuleFactory.Create(rules).ToList();

            Assert.Equal(3, pricingRules.Count);
            Assert.IsType<SpecialPriceRule>(pricingRules[0]);
            Assert.IsType<SimplePriceRule>(pricingRules[1]);
            Assert.IsType<SimplePriceRule>(pricingRules[2]);

            Assert.Equal("A", pricingRules[0].Item);
            Assert.Equal("B", pricingRules[1].Item);
            Assert.Equal("C", pricingRules[2].Item);
        }

        [Fact]
        public void Create_WithNullRules_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => PriceRuleFactory.Create(null).ToList());
        }

        [Fact]
        public void Create_WithEmptyRules_ShouldReturnEmptyCollection()
        {
            var pricers = PriceRuleFactory.Create(Enumerable.Empty<PricingRule>());
            Assert.Empty(pricers);
        }

    }
}