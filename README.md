# 🪙 CryptoPeek

> A cryptocurrency information application built with WPF and MVVM architecture

## 📋 Overview

CryptoPeek provides comprehensive information about cryptocurrencies.

## ✨ Features

### 🏠 Homepage
- Browse a comprehensive list of cryptocurrencies
- View brief descriptions for each currency
- **Smart Search**: Find cryptocurrencies by name or symbol
- Quick navigation with double-click to view details

### 📊 Detailed Information Page
- **Сurrent price**
- **7-Day Chart**: Visual representation of price changes over the last week
- **Exchange Trades**: Complete list of trades across various exchanges
- **Quick Links**: Access relevant resources and official links

## 🛠️ Tech Stack

- **Framework**: WPF (Windows Presentation Foundation)
- **Architecture**: MVVM using Prism Library
- **API**: CoinGecko API

## ⚙️ Setup

### Prerequisites
- .NET 6.0 or higher
- CoinGecko API key

### Configuration
1. Obtain an API key from [CoinGecko](https://www.coingecko.com/en/api)
2. Add the API key to User Secrets:
```bash
   dotnet user-secrets set "coingecko_api_key" "YOUR_API_KEY_HERE"
