using Newtonsoft.Json;

namespace BaasBoxNet.Models
{
    internal class BaasServerError
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("API_version")]
        public string ApiVersion { get; set; }
    }
}