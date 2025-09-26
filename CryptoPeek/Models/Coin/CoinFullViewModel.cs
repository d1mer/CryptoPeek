using Newtonsoft.Json;

namespace CryptoPeek.Models.Coin
{
    public class CoinFullViewModel 
    {
        public string Id { get; set; }
        public string Image { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string HashingAlgorithm { get; set; }

        public DateTime GenesisDate { get; set; }

        public int? MarketCapRank { get; set; }

        public MarketDataViewModel MarketData { get; set; }
    }

    public class MarketDataViewModel
    {
        public Dictionary<string, decimal> CurrentPrice { get; set; }

        public Dictionary<string, decimal> MarketCap { get; set; }

        public decimal? TotalSupply { get; set; }

        public decimal? CirculatingSupply { get; set; }

        public decimal? MaxSupply { get; set; }
    }
}
