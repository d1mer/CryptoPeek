using Newtonsoft.Json;

namespace CryptoPeek.Models.Coin
{
    public class CoinDetailsModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("hashing_algorithm")]
        public string HashingAlgorithm { get; set; }

        [JsonProperty("description")]
        public Dictionary<string, string> Description { get; set; }

        [JsonProperty("links")]
        public CoinLinks Links { get; set; }

        [JsonProperty("image")]
        public CoinImages Image { get; set; }

        [JsonProperty("genesis_date")]
        public DateTime? GenesisDate { get; set; }

        [JsonProperty("market_cap_rank")]
        public int? MarketCapRank { get; set; }

        [JsonProperty("market_data")]
        public MarketData MarketData { get; set; }
    }

    public class CoinLinks
    {
        [JsonProperty("homepage")]
        public List<string> Homepage { get; set; }

        [JsonProperty("whitepaper")]
        public string Whitepaper { get; set; }

        [JsonProperty("blockchain_site")]
        public List<string> BlockchainSite { get; set; }

        [JsonProperty("official-forum-url")]
        public List<string> OfficialForumUrl { get; set; }

        [JsonProperty("chat_url")]
        public List<string> ChatUrl { get; set; }

        [JsonProperty("announcement_url")]
        public List<string> AnnouncementUrl { get; set; }

        [JsonProperty("snapshot_url")]
        public string SnapshotUrl { get; set; }

        [JsonProperty("subreddit_url")]
        public string SubredditUrl { get; set; }

        [JsonProperty("repos_url")]
        public CoinLinksRepos ReposUrl { get; set; }
    }

    public class CoinLinksRepos
    {
        [JsonProperty("github")]
        public List<string> Github { get; set; }

        [JsonProperty("bitbucket")]
        public List<string> Bitbucket { get; set; }
    }

    public class CoinImages
    {
        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }
    }

    public class MarketData
    {
        [JsonProperty("current_price")]
        public Dictionary<string, decimal> CurrentPrice { get; set; } 

        [JsonProperty("market_cap")]
        public Dictionary<string, decimal> MarketCap { get; set; }

       [JsonProperty("total_supply")]
        public decimal? TotalSupply { get; set; }

        [JsonProperty("circulating_supply")]
        public decimal? CirculatingSupply { get; set; }

        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; }
    }
}
