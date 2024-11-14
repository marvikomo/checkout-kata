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

        [Theory]
        [InlineData(0, 0)]    
        [InlineData(1, 50)] 
        [InlineData(2, 100)] 
        public void CalculateTotal_ShouldReturnCorrectAmount(int quantity, int expected)
        {
            var pricer = new SimplePriceRule("A", 50);
            var total = pricer.CalculateTotal(quantity);
            Assert.Equal(expected, total);
        }
    }
}