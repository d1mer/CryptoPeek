using Newtonsoft.Json;

namespace CryptoPeek.Models.Coin
{
    public class CoinModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string  Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("current_price")]
        public decimal CurrentPrice { get; set; }

        [JsonProperty("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonProperty("market_cap_rank")]
        public int? MarketCapRank { get; set; }

        [JsonProperty("fully_diluted_valuation")]
        public decimal? FullyDilutedValuation { get; set; }

        [JsonProperty("total_volume")]
        public decimal TotalVolume { get; set; }

        [JsonProperty("high_24h")]
        public decimal? High24h { get; set; }

        [JsonProperty("low_24h")]
        public decimal? Low24h { get; set; }

        [JsonProperty("price_change_24h")]
        public decimal? PriceChange24h { get; set; }

        [JsonProperty("price_change_percentage_24h")]
        public decimal? PriceChangePercentage24h { get; set; }

        [JsonProperty("market_cap_change_24h")]
        public decimal? MarketCapChange24h { get; set; }

        [JsonProperty("market_cap_change_percentage_24h")]
        public decimal? MarketCapChangePercentage24h { get; set; }

        [JsonProperty("circulating_supply")]
        public decimal? CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public decimal? TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; }

        [JsonProperty("ath")]
        public decimal? Ath { get; set; }

        [JsonProperty("ath_change_percentage")]
        public decimal? AthChangePercentage { get; set; }

        [JsonProperty("ath_date")]
        public DateTime? AthDate { get; set; }

        [JsonProperty("atl")]
        public decimal? Atl { get; set; }

        [JsonProperty("atl_change_percentage")]
        public decimal? AtlChangePercentage { get; set; }

        [JsonProperty("atl_date")]
        public DateTime? AtlDate { get; set; }

        [JsonProperty("roi")]
        public Roi Roi { get; set; }

        [JsonProperty("last_updated")]
        public DateTime? LastUpdated { get; set; }
    }


    public class Roi
    {
        [JsonProperty("times")]
        public decimal? Times { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("percentage")]
        public decimal? Percentage { get; set; }
    }
}
