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
            };

            if (coinDetailsModel.Description.ContainsKey("en"))
            {
                coinFull.Description = coinDetailsModel.Description["en"];
            }

            coinFull.MarketData = new MarketDataViewModel();
            coinFull.MarketData.CurrentPrice = new Dictionary<string, decimal>(coinDetailsModel.MarketData.CurrentPrice);

            return coinFull;
        }
    }
}
