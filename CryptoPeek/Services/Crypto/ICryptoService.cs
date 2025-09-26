using CryptoPeek.Models.Coin;

namespace CryptoPeek.Services.Crypto
{
    public interface ICryptoService
    {
        Task<List<CoinModel>> GetCoinsList();

        Task<CoinDetailsModel> GetCoinById(string id);
    }
}
