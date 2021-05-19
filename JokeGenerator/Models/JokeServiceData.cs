using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.Models
{
    public class JokeServiceData: BaseServiceData
    {
        /// <summary>
        /// Uri path to get joke
        /// </summary>
        public string JokePath { get; set; }
    }
}
