using CryptoPeek.Models.Coin;
using CryptoPeek.Models.Tickers;
using CryptoPeek.Services.Rest;
using System.Collections.Generic;

namespace CryptoPeek.Services.Crypto
{
    public class CryptoService : ICryptoService
    {
        private readonly IRestService _restService;

        public CryptoService(IRestService restService)
        {
            _restService = restService;
        }

        #region -- ICryptoService implementation --

        public async Task<List<CoinModel>> GetCoinsListAsync()
        {
            var result = new List<CoinModel>();

            try
            {
                var responce = await _restService.GetAsync<List<CoinModel>, object>(Constants.WebAPI.COINGECKO_BASE_URL + Constants.WebAPI.COINS_LIST, GetApiKeyHeaderDictionary());
                
                if (responce.IsSuccess)
                {
                    result.AddRange(responce.SuccessResult);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CryptoService.GetCoinsList error: {ex.Message}");
            }

            return result;
        }

        public async Task<CoinDetailsModel> GetCoinByIdAsync(string id)
        {
            CoinDetailsModel coin = default;

            try
            {
                var responce = await _restService.GetAsync<CoinDetailsModel, object>(Constants.WebAPI.COINGECKO_BASE_URL + string.Format(Constants.WebAPI.COIN_BY_ID, id), GetApiKeyHeaderDictionary());

                if (responce.IsSuccess)
                {
                    coin = responce.SuccessResult;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CryptoService.GetCoinById error: {ex.Message}");
            }

            return coin;
        }

        public async Task<List<List<object>>> GetOhlcByCoinIdAsync(string id)
        {
            var result = new List<List<object>>();

            try
            {
                var responce = await _restService.GetAsync<List<List<object>>, object>(Constants.WebAPI.COINGECKO_BASE_URL + string.Format(Constants.WebAPI.OHLC_BY_COIN_ID, id), GetApiKeyHeaderDictionary());

                if (responce.IsSuccess)
                {
                    result = responce.SuccessResult;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CryptoService.GetOhlcByCoinId error: {ex.Message}");
            }

            return result;
        }

        public async Task<List<TickerModel>> GetTickersByCoinIdAsync(string id)
        {
            var result = new List<TickerModel>();

            try
            {
                var responce = await _restService.GetAsync<TickersResponceModel, object>(Constants.WebAPI.COINGECKO_BASE_URL + string.Format(Constants.WebAPI.TICKERS_BY_COIN_ID, id), GetApiKeyHeaderDictionary());

                if (responce.IsSuccess)
                {
                    result.AddRange(responce.SuccessResult.Tickers);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CryptoService.GetTickersByCoinId error: {ex.Message}");
            }

            return result;
        }

        #endregion

        #region -- Private helpers --

        private Dictionary<string, string> GetApiKeyHeaderDictionary()
        {
            var result = new Dictionary<string, string>();
            result[Constants.API_KEY_HEADER_NAME] = App.Configuration[Constants.COINGECKO_API_KEY_NAME];

            return result;
        }

        #endregion
    }
}
