using System;
using CheckoutKata.Services.PricingRules;


namespace CheckoutKata.Services.Tests.PriceRuleFactory
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

    }
}