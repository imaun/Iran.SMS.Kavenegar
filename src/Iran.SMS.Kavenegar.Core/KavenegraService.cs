using System;
using Iran.SMS.Kavenegar.Core.Internal;
using Iran.SMS.Kavenegar.Core.Extensions;

namespace Iran.SMS.Kavenegar.Core
{
    public class KavenegraService
    {
        #region Constants

        private const string __API_URL_FORMAT = @"https://api.kavenegar.com/v1/{API-KEY}/{Scope}/{Method}.json";

        #endregion

        private readonly IHttpRestClient _httpClient;

        public KavenegraService(IHttpRestClient httpClient) {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }


        private string getApiUrl(string apiKey, string scope, string method)
            => __API_URL_FORMAT
                .Replace("{API-KEY}", apiKey)
                .Replace("{Scope}", scope)
                .Replace("{Method}", method);
                

        


    }
}
