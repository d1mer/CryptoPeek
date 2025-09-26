namespace CryptoPeek
{
    public static class Constants
    {
        public const string COINGECKO_API_KEY_NAME = "coingecko_api_key";
        public const string API_KEY_HEADER_NAME = "x-cg-demo-api-key";

        public static class WebAPI
        {
            public const string COINGECKO_BASE_URL = @"https://api.coingecko.com/api/v3/";
            public const string COINS_LIST = @"coins/markets?vs_currency=usd";
            public const string COIN_BY_ID = @"coins/{0}?localization=false&tickers=false&developer_data=false&community_data=false";
        }
    }
}
