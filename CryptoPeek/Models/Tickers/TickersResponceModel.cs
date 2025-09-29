using Newtonsoft.Json;


namespace CryptoPeek.Models.Tickers
{
    public class TickersResponceModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tickers")]
        public List<TickerModel> Tickers { get; set; }
    }
}
