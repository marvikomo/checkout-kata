using System;

using CheckoutKata.Services.Interfaces;

namespace CheckoutKata.Services
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> _scannedItems = new();

         private readonly Dictionary<string, int> _prices = new()
        {
            { "A", 50 },
            { "B", 30 },
            { "C", 20 },
            { "D", 15 }
        };
        public Checkout() {

        }

        public void Scan(string item) {
            if(!_prices.ContainsKey(item))
            {
                throw new ArgumentException($"Invalid item: {item}");
            }
            if(!_scannedItems.ContainsKey(item))
                _scannedItems[item] = 0;
            _scannedItems[item]++;
            
        }

        public int GetTotalPrice() {
          int total = 0;
          foreach (var item in _scannedItems)
          {
            string sku = item.Key;
            int quantity = item.Value;

            if(sku == "A") 
            {
                int groupsOfThree = quantity / 3;
                int remainingAs = quantity % 3;
                total += (groupsOfThree * 130) + (remainingAs * 50);
            }
            else
            {
            total += quantity * _prices[sku];
            }
            
          }
          return total;
        }
    }
}