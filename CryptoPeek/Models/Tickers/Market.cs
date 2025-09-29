using Newtonsoft.Json;

namespace CryptoPeek.Models.Tickers
{
    public class Market
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("as_trading_incentive")]
        public bool AsTradingIncentive { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}
