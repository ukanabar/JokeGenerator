using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.Models
{
    /// <summary>
    /// POCO for application settings
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Name service client data.
        /// </summary>
        public NameServiceData nameServiceData { get; set; }

        /// <summary>
        /// Joke service client data.
        /// </summary>
        public JokeServiceData jokeServiceData { get; set; }

        /// <summary>
        /// Caching configuration.
        /// </summary>
        public CachePolicy cachePolicy { get; set; }        

    }
}
