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

        private readonly Dictionary<string, (int quantity, int specialPrice)> _specialOffers = new()
        {
            { "A", (3, 130) },
            { "B", (2, 45) }
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

            if(_specialOffers.ContainsKey(sku))
            {
                var (specialQuantity, specialPrice) = _specialOffers[sku];
                int specialGroups = quantity / specialQuantity;
                int remainingItems = quantity % specialQuantity;
                total += (specialGroups * specialPrice) + (remainingItems * _prices[sku]);
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