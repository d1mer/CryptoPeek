using CryptoPeek.Models.Coin;
using CryptoPeek.Models.Tickers;

namespace CryptoPeek.Services.Crypto
{
    public interface ICryptoService
    {
        Task<List<CoinModel>> GetCoinsListAsync();

        Task<CoinDetailsModel> GetCoinByIdAsync(string id);

        Task<List<List<object>>> GetOhlcByCoinIdAsync(string id);

        Task<List<TickerModel>> GetTickersByCoinIdAsync(string id);
    }
}
