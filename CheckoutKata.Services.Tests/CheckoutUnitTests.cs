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

       
       

        

    }
}