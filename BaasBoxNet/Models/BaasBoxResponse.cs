using Newtonsoft.Json;

namespace BaasBoxNet.Models
{
    public sealed class BaasBoxResponse<T>
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("http_code")]
        public int HttpCode { get; set; }
    }
}