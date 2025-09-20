using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CryptoPeek.Helpers;

namespace CryptoPeek.Services.Rest
{
    public class RestService : IRestService
    {
        #region -- IRestService implementation --

        public Task<ServerResponse<TSuccess, TError>> GetAsync<TSuccess, TError>(string resource, Dictionary<string, string> additionalHeaders = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region -- Private helpers --

        private HttpContent CreateContent(object requestBody)
        {
            var result = default(HttpContent);

            if (requestBody is HttpContent httpContent)
            {
                result = httpContent;
            }
            else
            {
                var jsonString = JsonConvert.SerializeObject(requestBody, converters: new JsonConverter[] { new IsoDateTimeConverter() });
                result = new StringContent(jsonString, Encoding.UTF8, "application/json");
            }

            return result;
        }

        private Dictionary<string, string> CreatetHeaders(Dictionary<string, string> additionalHeaders = null)
        {
            if (additionalHeaders == null)
            {
                additionalHeaders = new Dictionary<string, string>();
            }

            var defaultHeaders = new Dictionary<string, string>();
            defaultHeaders["Accept"] = "application/json";

            foreach(var kv in additionalHeaders)
            {
                defaultHeaders[kv.Key] = kv.Value;
            }

            return defaultHeaders;
        }

        private HttpClient CreateHttpClient(Dictionary<string, string> headerParams = null)
        {
            var httpClient = new HttpClient();

            if (headerParams != null)
            {
                foreach (var headerParam in headerParams)
                {
                    httpClient.DefaultRequestHeaders.Add(headerParam.Key, headerParam.Value);
                }
            }

            return httpClient;
        }

        private async Task<ServerResponse<TSuccess, TError>> SendRequest<TSuccess, TError>(HttpRequestMessage request, Dictionary<string, string> additionalHeaders = null)
        {
            var result = new ServerResponse<TSuccess, TError>();

            using (var httpClient = CreateHttpClient(CreatetHeaders(additionalHeaders)))
            using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
            {
                var responseString = await response.Content.ReadAsStringAsync();

                result.IsSuccess = response.IsSuccessStatusCode;
                result.StatusCode = (int)response.StatusCode;

                if (response.IsSuccessStatusCode)
                {
                    result.SuccessResult = JsonConvert.DeserializeObject<TSuccess>(responseString, converters: new JsonConverter[] { new IsoDateTimeConverter() });
                }
                else
                {
                    result.ErrorResult = JsonConvert.DeserializeObject<TError>(responseString, converters: new JsonConverter[] { new IsoDateTimeConverter() });
                }
            }

            return result;
        }

        #endregion
    }
}
