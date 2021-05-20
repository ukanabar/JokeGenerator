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

        /// <summary>
        /// first name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// last name
        /// </summary>
        [JsonPropertyName("surname")]
        public string SurName { get; set; }

        /// <summary>
        /// gender
        /// </summary>
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// region
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }
    }
}
