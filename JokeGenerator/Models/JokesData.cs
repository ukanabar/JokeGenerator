using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JokeGenerator.Models
{
    /// <summary>
    /// Model class for jokes
    /// </summary>
    public class JokesData
    {
        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
