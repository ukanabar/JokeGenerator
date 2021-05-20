using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.Models
{
    /// <summary>
    /// POCO for base client service data
    /// </summary>
    public class BaseServiceData
    {
        /// <summary>
        /// Base address.
        /// </summary>
        public string BaseAddress { get; set; }

        /// <summary>
        /// Uri
        /// </summary>
        public string Path { get; set; }        
    }
}
