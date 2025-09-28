namespace CryptoPeek.Models.Ohlc
{
    public class OhlcViewModel
    {
        public DateTime Time { get; set; }

        public double OpenPrice { get; set; }

        public double HighPrice { get; set; }

        public double LowPrice { get; set; }

        public double ClosePrice { get; set; }
    }
}
