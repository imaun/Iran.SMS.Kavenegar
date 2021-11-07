using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace System.Net.Http {

    public interface IHttpRestClient {
        Task<TResult> PostAsync<T, TResult>(
            T data,
            string url,
            Dictionary<string, string> headers = null);

        Task<TResult> PostFormAsync<TResult>(
            IEnumerable<KeyValuePair<string, string>> data,
            string url,
            Dictionary<string, string> headers = null);
    }

    public class HttpRestClient : IHttpRestClient {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public HttpRestClient(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory
                ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpClient = _httpClientFactory.CreateClient();
        }

        private void addHeaders(Dictionary<string, string> headers = null) {
            _httpClient.DefaultRequestHeaders.Clear();
            foreach (var item in headers ?? new Dictionary<string, string>())
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, item.Value);
        }

        public async Task<TResult> PostAsync<T, TResult>(
            T data,
            string url,
            Dictionary<string, string> headers = null) {
            addHeaders(headers);

            var json = JsonConvert.SerializeObject(data);
            var input = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");
            input.Headers.ContentLength = Encoding.UTF8.GetByteCount(json);

            var result = await _httpClient.PostAsync(
                url,
                input
            );

            if (!result.IsSuccessStatusCode)
			{
				throw new HttpRequestException(
                    $"{result.StatusCode} {result.ReasonPhrase}");
			}

			var content = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(content);
        }

        public async Task<TResult> PostFormAsync<TResult>(
            IEnumerable<KeyValuePair<string, string>> data,
            string url,
            Dictionary<string, string> headers = null) {
            addHeaders(headers);

            var formData = new FormUrlEncodedContent(data);
            //formData.Headers.ContentLength = Encoding.UTF8.GetByteCount(await formData.ReadAsStringAsync());

            var result = await _httpClient.PostAsync(
                url,
                formData);

            if (!result.IsSuccessStatusCode)
			{
				throw new HttpRequestException(
                    $"{result.StatusCode} {result.ReasonPhrase}");
			}

			var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content);
        }
    }
}
