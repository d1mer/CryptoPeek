namespace CryptoPeek.Models.Coin
{
    public class CoinFullViewModel 
    {
        public string Id { get; set; }
        public string Image { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MarketDataViewModel MarketData { get; set; }
    }

    public class MarketDataViewModel
    {
        public Dictionary<string, decimal> CurrentPrice { get; set; }
    }
}
