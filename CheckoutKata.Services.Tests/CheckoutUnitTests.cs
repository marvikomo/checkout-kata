using System;
using CheckoutKata.Services.Interfaces;
using CheckoutKata.Services.Model;


namespace CheckoutKata.Services.Tests
{
    public class CheckoutUnitTests
    {
        private static IEnumerable<PricingRule> CreateDefaultRules()
        {
            return new[]
            {
            new PricingRule("A", 50, new SpecialOffer(3, 130)),
            new PricingRule("B", 30, new SpecialOffer(2, 45)),
            new PricingRule("C", 20),
            new PricingRule("D", 15)
        };
        }

        [Fact]
        public void WhenNoItems_TotalShouldBeZero()
        {
            var checkout = new Checkout(CreateDefaultRules());
            Assert.Equal(0, checkout.GetTotalPrice());
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        public void WhenSingleItem_ShouldReturnUnitPrice(string item, int expectedPrice)
        {
            var checkout = new Checkout(CreateDefaultRules());
            checkout.Scan(item);
            Assert.Equal(expectedPrice, checkout.GetTotalPrice());
        }

        [Fact]
        public void WhenInvalidItem_ShouldThrowException()
        {
            var checkout = new Checkout(CreateDefaultRules());
            Assert.Throws<ArgumentException>(() => checkout.Scan("X"));
        }

        [Fact]
        public void WhenThreeAs_ShouldApplySpecialPrice()
        {
            var checkout = new Checkout(CreateDefaultRules());
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.Equal(130, checkout.GetTotalPrice());
        }


        [Fact]
        public void WhenTwoBs_ShouldApplySpecialPrice()
        {
            var checkout = new Checkout(CreateDefaultRules());
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
            var checkout = new Checkout(CreateDefaultRules());
            foreach (var item in items)
            {
                checkout.Scan(item);
            }
            Assert.Equal(expectedTotal, checkout.GetTotalPrice());
        }

        [Fact]
        public void WhenNullRules_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Checkout(null));
        }

       
        [Fact]
        public void WhenCustomRules_ShouldUseCustomPricing()
        {
            var customRules = new[]
            {
                new PricingRule("X", 10, new SpecialOffer(2, 15)),
                new PricingRule("Y", 20)
            };

            ICheckout checkout = new Checkout(customRules);
            checkout.Scan("X");
            checkout.Scan("X");
            checkout.Scan("Y");
            Assert.Equal(35, checkout.GetTotalPrice()); 
        }

       

        [Theory]
        [InlineData(new[] { "A", "A", "A", "B", "B", "D" }, 190)]  // 3A special (130) + 2B special (45) + D (15)
        [InlineData(new[] { "B", "A", "B", "A", "A", "C" }, 195)]  // 3A special (130) + 2B special (45) + C (20)
        [InlineData(new[] { "D", "B", "D", "A", "B", "A", "A" }, 205)]  // 3A special (130) + 2B special (45) + 2D (30)
        public void WhenComplexScenarios_ShouldCalculateCorrectly(string[] items, int expectedTotal)
        {
            ICheckout checkout = new Checkout(CreateDefaultRules());
            foreach (var item in items)
            {
                checkout.Scan(item);
            }
            Assert.Equal(expectedTotal, checkout.GetTotalPrice());
        }
        

        [Fact]
        public void WhenLargeQuantity_ShouldCalculateCorrectly()
        {
            ICheckout checkout = new Checkout(CreateDefaultRules());
            // Scan 10 of each item
            for (int i = 0; i < 10; i++)
            {
                checkout.Scan("A"); 
                checkout.Scan("B"); 
                checkout.Scan("C"); 
                checkout.Scan("D");  
            }
            Assert.Equal(1015, checkout.GetTotalPrice());
        }


        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void WhenInvalidItemFormat_ShouldThrowException(string invalidItem)
        {
            ICheckout checkout = new Checkout(CreateDefaultRules());
            Assert.Throws<ArgumentException>(() => checkout.Scan(invalidItem));
        }
       


    }
}