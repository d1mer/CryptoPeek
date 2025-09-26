using Newtonsoft.Json;
using System.Security.Policy;

namespace CryptoPeek.Models.Coin
{
    public class CoinDetailsModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }  // done

        [JsonProperty("symbol")]
        public string Symbol { get; set; }  // done

        [JsonProperty("name")]
        public string Name { get; set; }  // done

        [JsonProperty("hashing_algorithm")]
        public string HashingAlgorithm { get; set; }  // done

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("description")]
        public Dictionary<string, string> Description { get; set; } // done

        [JsonProperty("links")]
        public CoinLinks Links { get; set; }

        [JsonProperty("image")]
        public CoinImages Image { get; set; }  // done

        [JsonProperty("genesis_date")]
        public DateTime GenesisDate { get; set; }  // done

        [JsonProperty("market_cap_rank")]
        public int? MarketCapRank { get; set; } // done

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
        public Dictionary<string, decimal> CurrentPrice { get; set; }  // done

        [JsonProperty("roi")]
        public Roi Roi { get; set; }

        [JsonProperty("market_cap")]
        public Dictionary<string, decimal> MarketCap { get; set; }  // done

        [JsonProperty("total_volume")]
        public Dictionary<string, decimal> TotalVolume { get; set; }

        [JsonProperty("high_24h")]
        public Dictionary<string, decimal> High24h { get; set; }

        [JsonProperty("low_24h")]
        public Dictionary<string, decimal> Low24h { get; set; }

        [JsonProperty("price_change_24h")]
        public decimal? PriceChange24h { get; set; }

        [JsonProperty("price_change_percentage_24h")]
        public decimal? PriceChangePercentage24h { get; set; }

        [JsonProperty("price_change_percentage_7d")]
        public decimal? PriceChangePercentage7d { get; set; }

        [JsonProperty("price_change_percentage_14d")]
        public decimal? PriceChangePercentage14d { get; set; }

        [JsonProperty("price_change_percentage_30d")]
        public decimal? PriceChangePercentage30d { get; set; }

        [JsonProperty("price_change_percentage_60d")]
        public decimal? PriceChangePercentage60d { get; set; }

        [JsonProperty("price_change_percentage_200d")]
        public decimal? PriceChangePercentage200d { get; set; }

        [JsonProperty("price_change_percentage_1y")]
        public decimal? PriceChangePercentage1y { get; set; }

        [JsonProperty("market_cap_change_24h")]
        public decimal? MarketCapChange24h { get; set; }

        [JsonProperty("total_supply")]
        public decimal? TotalSupply { get; set; } // done

        [JsonProperty("circulating_supply")]
        public decimal? CirculatingSupply { get; set; } // done

        [JsonProperty("max_supply")]
        public decimal? MaxSupply { get; set; } // done
    }
}
