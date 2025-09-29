    namespace CryptoPeek.Models.Tickers
{
    public class TickerViewModel
    {
        public string Logo { get; set; }

        public string MarketName { get; set; }

        public string BaseTarget { get; set; }

        public decimal LastPrice { get; set; }

        public decimal Volume24h { get; set; }

        public decimal SpreadPercentage { get; set; }

        public string TradeUrl { get; set; }
    }
}
