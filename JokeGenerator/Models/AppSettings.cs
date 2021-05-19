using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.Models
{
    public class AppSettings
    {
        public NameServiceData nameServiceData { get; set; }

        public JokeServiceData jokeServiceData { get; set; }

        public CachePolicy cachePolicy { get; set; }

    }
}
