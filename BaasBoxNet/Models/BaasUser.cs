using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BaasBoxNet.Models
{
    public class BaasUser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("roles")]
        public IEnumerable<Dictionary<string, string>> Roles { get; set; }

        [JsonProperty("signUpDate")]
        public DateTime SignupDate { get; set; }

        [JsonProperty("X-BB-SESSION")]
        public string Session { get; set; }
    }
}