using Newtonsoft.Json;

namespace BaasBoxNet.Models
{
    public abstract class BaasDocument
    {
        [JsonProperty("@version")]
        public int BaasDocumentVersion { get; set; }

        [JsonProperty("@rid")]
        public string BaasDocumentRid { get; set; }

        [JsonProperty("@class")]
        public string BaasDocumentClass { get; set; }

        [JsonProperty("id")]
        public string BaasDocumentId { get; set; }

        [JsonProperty("_creation_date")]
        public string BaasDocumentCreationDate { get; set; }

        [JsonProperty("_author")]
        public string BaasDocumentAuthor { get; set; }
    }
}