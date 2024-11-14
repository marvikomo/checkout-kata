using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutKata.Services.Model
{
   public record PricingRule(string Item, int UnitPrice, SpecialOffer? Special = null);
}