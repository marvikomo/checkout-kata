using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutKata.Services.Interfaces
{
    public interface IPricingRule
    {
        int CalculateTotal(int quantity);
    }
}