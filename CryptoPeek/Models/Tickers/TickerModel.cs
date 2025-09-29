using Newtonsoft.Json;

namespace CryptoPeek.Models.Tickers
{
    public class TickerModel
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("market")]
        public Market Market { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        [JsonProperty("bid_ask_spread_percentage")]
        public decimal Spread { get; set; }

        [JsonProperty("trade_url")]
        public string TradeUrl { get; set; }
    }
}
