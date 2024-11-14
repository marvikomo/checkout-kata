using System;
using CheckoutKata.Services.PricingRules;


namespace CheckoutKata.Services.Tests.PricingRules
{
    public class SpecialPriceRuleTest
    {
        [Fact]
        public void Item_ShouldReturnCorrectSku()
        {
            var pricer = new SpecialPriceRule("A", 50, 3, 130);
            Assert.Equal("A", pricer.Item);
        }

    }
}