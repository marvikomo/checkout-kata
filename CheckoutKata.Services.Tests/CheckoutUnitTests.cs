using System;


namespace CheckoutKata.Services.Tests
{
    public class CheckoutUnitTests
    {
        [Fact]
        public void WhenNoItems_TotalShouldBeZero()
        {
            var checkout = new Checkout();
            Assert.Equal(0, checkout.GetTotalPrice());
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        public void WhenSingleItem_ShouldReturnUnitPrice(string item, int expectedPrice)
        {
            var checkout = new Checkout();
            checkout.Scan(item);
            Assert.Equal(expectedPrice, checkout.GetTotalPrice());
        }

       
       

        

    }
}