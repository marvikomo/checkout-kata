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


        [Theory]
        [InlineData(0, 0)]       // Zero quantity
        [InlineData(1, 50)]      // Single item - normal price
        [InlineData(2, 100)]     // Two items - normal price
        [InlineData(3, 130)]     // Three items - special price
        [InlineData(4, 180)]     // Four items - special price + normal price
        [InlineData(6, 260)]     // Six items - two special prices
        public void CalculateTotal_ShouldReturnCorrectAmount(int quantity, int expected)
        {
            var pricer = new SpecialPriceRule("A", 50, 3, 130);
            var total = pricer.CalculateTotal(quantity);
            Assert.Equal(expected, total);
        }

    }
}