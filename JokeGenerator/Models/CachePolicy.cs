using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.Models
{
    /// <summary>
    /// POCO for cache configuration
    /// </summary>
    public class CachePolicy
    {
        /// <summary>
        /// Absolute Expiry For Cache
        /// </summary>
        public int AbsouluteExpiry { get; set; }        
    }
}
