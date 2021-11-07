using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Iran.SMS.Kavenegar.Core.Models;
using Iran.SMS.Kavenegar.Core.Internal;
using Iran.SMS.Kavenegar.Core.Extensions;

namespace Iran.SMS.Kavenegar.Core {

    public class KavenegarService: IKavenegarService {

        #region Constants

        private const string __API_URL_FORMAT = @"https://api.kavenegar.com/v1/{API-KEY}/{Scope}/{Method}.json";

        #endregion

        private readonly IHttpRestClient _httpClient;
        
        public KavenegarService(IHttpRestClient httpClient) 
            => _httpClient = httpClient 
                    ?? throw new ArgumentNullException(nameof(httpClient));

        public KavenegarService(
            IHttpRestClient httpClient,
            string apiKey) {
            _httpClient = httpClient 
                ?? throw new ArgumentNullException(nameof(httpClient));
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(nameof(apiKey));
            ApiKey = apiKey;
        }

        #region Properties

        public string ApiKey { get; set; }

        #endregion

        private string getApiUrl(string scope, string method)
            => __API_URL_FORMAT
                .Replace("{API-KEY}", ApiKey)
                .Replace("{Scope}", scope)
                .Replace("{Method}", method);

        private Dictionary<string, string> _baseHeaders = 
            new Dictionary<string, string> {
            {"Content-Type", "application/x-www-form-urlencoded"}
        };

        /// <inheritdoc/>
        public async Task<SendSmsOutput> SendAsync<T>(SendSmsInput<T> model) {
            if (model == null)
                throw new ArgumentNullException("Input model cannot be null.");

            string apiUrl = getApiUrl(scope: "sms", method: "send");
            var input = model.ToFormData();
            var result = await _httpClient
                .PostFormAsync<SendSmsOutput>(
                    data: input, 
                    url: apiUrl, 
                    headers: _baseHeaders);

            return await Task.FromResult(result);
        }

        /// <inheritdoc/>
        public async Task<VerifySmsOutput> VerifyAsync(VerifySmsInput model) {
            if (model == null)
                throw new ArgumentNullException("input model cannot be null.");

            string apiUrl = getApiUrl(scope: "verify", method: "lookup");
            var input = model.ToFormData();

            //var result = await _httpClient.PostAsync<VerifySmsInput, VerifySmsOutput>
            //    (model, apiUrl, _baseHeaders);

            var result = await _httpClient.PostFormAsync<VerifySmsOutput>
                (data: input, url: apiUrl, headers: null);

            return await Task.FromResult(result);
        }

    }
}
