using JokeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.Interfaces
{
    /// <summary>
    /// Service interface for name Service Provider 
    /// </summary>
    public interface INameService
    {
        /// <summary>
        /// Name service api calls to get random name
        /// </summary>
        /// <returns>Retruns random name details.</returns>
        Task<NameData> GetRandomName();
    }
}
