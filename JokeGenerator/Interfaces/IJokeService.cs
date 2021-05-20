using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.Interfaces
{
    /// <summary>
    /// Service interface for Joke Service Provider 
    /// </summary>
    public interface IJokeService
    {
        /// <summary>
        /// Joke service api calls to get categories
        /// </summary>
        /// <returns>Retruns key value pair for categories from joke service provider.</returns>
        Task<IDictionary<int, string>> GetCategories();

        /// <summary>
        /// Get joke by category from joke service provider
        /// </summary>
        /// <param name="category">joke category</param>
        /// <returns>Retruns single joke by category.</returns>
        Task<string> GetJoke(string category);


        /// <summary>
        /// Returns multiple jokes by category from joke service provider
        /// </summary>
        /// <param name="category">joke category</param>
        /// <param name="n">number of jokes</param>
        /// <param name="firstName">first name</param>
        /// <param name="lastName">lastname</param>
        /// <returns>Retruns multiple joke by category and also replaces chuck norris with specified first and last name.</returns>
        Task<List<string>> GetMultipleJokes(string category, int n, string firstName, string lastName);
    }
}
