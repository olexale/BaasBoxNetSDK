using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BaasBoxNet.Models;
using Newtonsoft.Json;

namespace BaasBoxNet.Services
{
    internal class RestService
    {
        private readonly BaasBox _box;

        internal RestService(BaasBox box)
        {
            _box = box;
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            using (var client = GetHttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(data);
                var requestBody = new StringContent(jsonData, Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(CreateRequestUrl(url), requestBody).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var parsedResponse = JsonConvert.DeserializeObject<BaasBoxResponse<T>>(content);
                    return parsedResponse.Data;
                }
            }
        }

        private string CreateRequestUrl(string url)
        {
            return string.Format("{0}:{1}/{2}", _box.Config.ApiDomain, _box.Config.HttpPort, url);
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            if (_box.User != null && !string.IsNullOrWhiteSpace(_box.User.Session))
                httpClient.DefaultRequestHeaders.Add("X-BAASBOX-APPCODE", _box.User.Session);
            return httpClient;
        }
    }
}