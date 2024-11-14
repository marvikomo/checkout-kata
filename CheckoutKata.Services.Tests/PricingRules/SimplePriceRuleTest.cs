using System;
using CheckoutKata.Services.PricingRules;


namespace CheckoutKata.Services.Tests.PricingRules
{
    public class SimplePriceRuleTest
    {
        [Fact]
        public void Item_ShouldReturnCorrectSku()
        {
            var pricer = new SimplePriceRule("A", 50);
            Assert.Equal("A", pricer.Item);
        }
    }
}