using CryptoPeek.Models.Coin;
using CryptoPeek.Models.Ohlc;

namespace CryptoPeek.Services.Crypto
{
    public interface ICryptoService
    {
        Task<List<CoinModel>> GetCoinsList();

        Task<CoinDetailsModel> GetCoinById(string id);

        Task<List<List<object>>> GetOhlcByCoinId(string id);
    }
}
