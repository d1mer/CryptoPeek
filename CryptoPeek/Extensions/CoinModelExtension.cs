using CryptoPeek.Models.Coin;
using System.Xml.Linq;

namespace CryptoPeek.Extensions
{
    public static class CoinModelExtension
    {
        public static CoinShortViewModel ToCoinShortViewModel(this CoinModel coinModel)
        {
            return new CoinShortViewModel
            {
                Id = coinModel.Id,
                Image = coinModel.Image,
                Symbol = coinModel.Symbol,
                Name = coinModel.Name,
                CurrentPrice = coinModel.CurrentPrice,
                PriceChangePercentage24h = coinModel.PriceChangePercentage24h,
                MarketCap = coinModel.MarketCap,
                TotalVolume = coinModel.TotalVolume,
            };
        }

        public static CoinFullViewModel ToCoinFullViewModel(this CoinDetailsModel coinDetailsModel)
        {
            var coinFull = new CoinFullViewModel
            {
                Id = coinDetailsModel.Id,
                Symbol = coinDetailsModel.Symbol,
                Name = coinDetailsModel.Name,
                Image = coinDetailsModel.Image.Large,
                HashingAlgorithm = coinDetailsModel.HashingAlgorithm,
                GenesisDate = coinDetailsModel.GenesisDate,
                MarketCapRank = coinDetailsModel.MarketCapRank,
            };

            if (coinDetailsModel.Description.ContainsKey("en"))
            {
                coinFull.Description = coinDetailsModel.Description["en"];
            }

            coinFull.MarketData = new MarketDataViewModel();
            coinFull.MarketData.CurrentPrice = new Dictionary<string, decimal>(coinDetailsModel.MarketData.CurrentPrice);
            coinFull.MarketData.MarketCap = new Dictionary<string, decimal>(coinDetailsModel.MarketData.MarketCap);
            coinFull.MarketData.CirculatingSupply = coinDetailsModel.MarketData.CirculatingSupply;
            coinFull.MarketData.TotalSupply = coinDetailsModel.MarketData.TotalSupply;
            coinFull.MarketData.MaxSupply = coinDetailsModel.MarketData.MaxSupply;

            if (coinDetailsModel.Links != null)
            {
                coinFull.Links = new System.Collections.ObjectModel.ObservableCollection<GroupUrls>();

                if (coinDetailsModel.Links.Homepage != null && coinDetailsModel.Links.Homepage.Count > 0)
                {
                    coinFull.Links.Add(new GroupUrls
                    {
                        Name = "Homepage",
                        Urls = new System.Collections.ObjectModel.ObservableCollection<string>(coinDetailsModel.Links.Homepage),
                    });
                }

                if (!string.IsNullOrEmpty(coinDetailsModel.Links.Whitepaper))
                {
                    coinFull.Links.Add(new GroupUrls
                    {
                        Name = "Whitepaper",
                        Urls = new System.Collections.ObjectModel.ObservableCollection<string>(new[] { coinDetailsModel.Links.Whitepaper }),
                    });
                }

                if (coinDetailsModel.Links.BlockchainSite != null && coinDetailsModel.Links.BlockchainSite.Count > 0)
                {
                    coinFull.Links.Add(new GroupUrls
                    {
                        Name = "Blockchain",
                        Urls = new System.Collections.ObjectModel.ObservableCollection<string>(coinDetailsModel.Links.BlockchainSite),
                    });
                }

                if (coinDetailsModel.Links.OfficialForumUrl != null && coinDetailsModel.Links.OfficialForumUrl.Count > 0)
                {
                    coinFull.Links.Add(new GroupUrls
                    {
                        Name = "Official Forums",
                        Urls = new System.Collections.ObjectModel.ObservableCollection<string>(coinDetailsModel.Links.OfficialForumUrl),
                    });
                }

                if (coinDetailsModel.Links.ChatUrl != null && coinDetailsModel.Links.ChatUrl.Count > 0)
                {
                    coinFull.Links.Add(new GroupUrls
                    {
                        Name = "Chats",
                        Urls = new System.Collections.ObjectModel.ObservableCollection<string>(coinDetailsModel.Links.ChatUrl),
                    });
                }

                if (coinDetailsModel.Links.AnnouncementUrl != null && coinDetailsModel.Links.AnnouncementUrl.Count > 0)
                {
                    coinFull.Links.Add(new GroupUrls
                    {
                        Name = "Announcements",
                        Urls = new System.Collections.ObjectModel.ObservableCollection<string>(coinDetailsModel.Links.AnnouncementUrl),
                    });
                }

                if (!string.IsNullOrEmpty(coinDetailsModel.Links.SnapshotUrl))
                {
                    coinFull.Links.Add(new GroupUrls
                    {
                        Name = "Snapshot",
                        Urls = new System.Collections.ObjectModel.ObservableCollection<string>(new[] { coinDetailsModel.Links.SnapshotUrl }),
                    });
                }

                if (!string.IsNullOrEmpty(coinDetailsModel.Links.SubredditUrl))
                {
                    coinFull.Links.Add(new GroupUrls
                    {
                        Name = "Subreddit",
                        Urls = new System.Collections.ObjectModel.ObservableCollection<string>(new[] { coinDetailsModel.Links.SubredditUrl }),
                    });
                }

                if (coinDetailsModel.Links.ReposUrl != null)
                {
                    if (coinDetailsModel.Links.ReposUrl.Github != null && coinDetailsModel.Links.ReposUrl.Github.Count > 0)
                    {
                        coinFull.Links.Add(new GroupUrls
                        {
                            Name = "Github",
                            Urls = new System.Collections.ObjectModel.ObservableCollection<string>(coinDetailsModel.Links.ReposUrl.Github),
                        });
                    }

                    if (coinDetailsModel.Links.ReposUrl.Bitbucket != null && coinDetailsModel.Links.ReposUrl.Bitbucket.Count > 0)
                    {
                        coinFull.Links.Add(new GroupUrls
                        {
                            Name = "Bitbucket",
                            Urls = new System.Collections.ObjectModel.ObservableCollection<string>(coinDetailsModel.Links.ReposUrl.Bitbucket),
                        });
                    }
                }
            }

            return coinFull;
        }
    }
}
