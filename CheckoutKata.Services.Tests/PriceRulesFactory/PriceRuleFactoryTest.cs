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

    }
}