using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JokeGenerator.Models
{
    /// <summary>
    /// Model class for random name
    /// </summary>

    public class NameData
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string SurName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }
    }
}
