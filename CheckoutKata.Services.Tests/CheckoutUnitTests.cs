using System;


namespace CheckoutKata.Services.Tests
{
    public class CheckoutUnitTests
    {
        [[Fact]
        public void WhenNoItems_TotalShouldBeZero()
        {
            var checkout = new Checkout();
            Assert.Equal(0, checkout.GetTotalPrice());
        }]
    }
}