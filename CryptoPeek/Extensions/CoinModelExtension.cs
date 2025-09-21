using CryptoPeek.Models.Coin;

namespace CryptoPeek.Extensions
{
    public static class CoinModelExtension
    {
        public static CoinShortViewModel ToCoinShortViewModel(this CoinModel coinModel)
        {
            return new CoinShortViewModel
            {
                Image = coinModel.Image,
                Symbol = coinModel.Symbol,
                Name = coinModel.Name,
                CurrentPrice = coinModel.CurrentPrice,
                PriceChangePercentage24h = coinModel.PriceChangePercentage24h,
                MarketCap = coinModel.MarketCap,
                TotalVolume = coinModel.TotalVolume,
            };
        }
    }
}
