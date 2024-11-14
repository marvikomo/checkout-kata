using System;

using CheckoutKata.Services.Interfaces;

namespace CheckoutKata.Services
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> _scannedItems = new();
        public Checkout() {

        }

        public void Scan(string item) {
            if(!_scannedItems.ContainsKey(item))
                _scannedItems[item] = 0;
            _scannedItems[item]++;
            
        }

        public int GetTotalPrice() {
           return _scannedItems.GetValueOrDefault("A", 0) * 50;
        }
    }
}