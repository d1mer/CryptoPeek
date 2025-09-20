using CryptoPeek.Helpers;

namespace CryptoPeek.Services.Rest
{
    public interface IRestService
    {
        Task<ServerResponse<TSuccess, TError>> GetAsync<TSuccess, TError>(string resource, Dictionary<string, string> additionalHeaders = null);
    }
}
