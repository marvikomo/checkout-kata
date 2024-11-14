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

        [Fact]
        public void WhenInvalidItem_ShouldThrowException(){
            var checkout = new Checkout();
            Assert.Throws<ArgumentException>( () => checkout.Scan("X"));
        }

        [Fact]
        public void WhenThreeAs_ShouldApplySpecialPrice()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.Equal(130, checkout.GetTotalPrice());
        }


        [Fact]
        public void WhenTwoBs_ShouldApplySpecialPrice()
        {
            var checkout = new Checkout();
            checkout.Scan("B");
            checkout.Scan("B");
            Assert.Equal(45, checkout.GetTotalPrice());
        }

        [Theory]
        [InlineData(new[] { "A", "A", "A" }, 130)]  // 3A special price
        [InlineData(new[] { "B", "B" }, 45)]        // 2B special price
        [InlineData(new[] { "A", "A", "A", "A" }, 180)]  // 3A special + 1A normal
        [InlineData(new[] { "B", "B", "B" }, 75)]   // 2B special + 1B normal
        public void WhenMultipleItems_ShouldApplySpecialPrice(string[] items, int expectedTotal)
        {
        var checkout = new Checkout();
        foreach (var item in items)
        {
            checkout.Scan(item);
        }
            Assert.Equal(expectedTotal, checkout.GetTotalPrice());
        }

       
       

        

    }
}