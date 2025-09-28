using CryptoPeek.Models.Ohlc;

namespace CryptoPeek.Extensions
{
    public static class OhlcModelExtension
    {
        public static OhlcViewModel ToOhlcViewModel(this List<object> rawData)
        {
            return new OhlcViewModel
            {
                Time = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(rawData[0])).UtcDateTime,
                OpenPrice = Convert.ToDouble(rawData[1]),
                HighPrice = Convert.ToDouble(rawData[2]),
                LowPrice = Convert.ToDouble(rawData[3]),
                ClosePrice = Convert.ToDouble(rawData[4]),
            };
        }
    }
}
