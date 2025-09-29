using CryptoPeek.Models.Tickers;

namespace CryptoPeek.Extensions
{
    public static class TickerModelExtension
    {
        public static TickerViewModel ToTickerViewModel(this TickerModel tickerModel)
        {
            return new TickerViewModel
            {
                Logo = tickerModel.Market.Logo,
                MarketName = tickerModel.Market.Name,
                BaseTarget = tickerModel.Base + "/" + tickerModel.Target,
                LastPrice = tickerModel.Last,
                Volume24h = tickerModel.Volume,
                SpreadPercentage = tickerModel.Spread,
                TradeUrl = tickerModel.TradeUrl,
            };
        }
    }
}
