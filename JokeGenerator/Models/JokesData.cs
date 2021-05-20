using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JokeGenerator.Models
{
    /// <summary>
    /// POCO for jokes
    /// </summary>
    public class JokesData
    {
        /// <summary>
        /// jokes icon url
        /// </summary>
        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        /// id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// jokes url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// jokes value
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
