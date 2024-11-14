# BrightHR Checkout Kata

This project implements a checkout system for an online store, following the principles of the Checkout Kata. The system allows users to scan items, calculate total prices, and apply special pricing rules based on item quantity.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Testing](#testing)
- [License](#license)


## Project Overview

The **BrightHR Checkout Kata** is designed to simulate a simple checkout system where:
- Each item has a price.
- Special offers apply to certain items based on the quantity purchased.
- Total price calculations reflect both regular and special offer prices.

This system provides flexibility to add new pricing rules and can handle various pricing configurations for different items.

## Features

- **Scan Items**: Scan items by SKU and add them to the checkout.
- **Total Price Calculation**: Calculate total cost of items in the cart, applying special pricing rules where applicable.
- **Custom Pricing Rules**: Define custom pricing rules through a factory-based approach to handle both regular and special pricing conditions.


## Architecture

This project is divided into several modules:

### Services
- **Checkout.cs**: The main checkout class responsible for scanning items, keeping track of the items in the cart, and calculating the total price. Special pricing is applied where configured.
- **Factories/PriceRuleFactory.cs**: Factory to create instances of pricing rules based on item configurations. Determines whether a simple or special pricing rule applies.
  
### Interfaces
- **ICheckout.cs**: Interface for the Checkout class, defining basic operations like `Scan` and `GetTotalPrice`.
- **IPricingRule.cs**: Interface for different pricing rule implementations, ensuring consistency across all rule types.

### Models
- **PricingRule.cs**: Represents a pricing rule configuration, including item details, unit price, and optional special offers.
- **SpecialOffer.cs**: Represents a special offer for an item, including quantity and the special price applicable.

### Pricing Rules
- **SimplePriceRule.cs**: Applies a straightforward price-per-unit model.
- **SpecialPriceRule.cs**: Applies a special pricing rule if the item quantity matches the specified condition for a discount.

### Tests
- **CheckoutUnitTests.cs**: Unit tests for the checkout system, ensuring correct calculations for single items, multiple items, and special pricing rules.

## Getting Started

### Prerequisites

- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) or higher

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/marvikomo/brighthr-checkout-kata.git
   cd brighthr-checkout-kata

