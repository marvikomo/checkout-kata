using System;

using CheckoutKata.Services.Interfaces;

namespace CheckoutKata.Services
{
    public class Checkout : ICheckout
    {
        public Checkout() {}

        public void Scan(string item) {}

        public int GetTotalPrice() {
           return 0;
        }
    }
}