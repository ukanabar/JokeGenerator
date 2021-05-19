using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.Interfaces
{
    public interface IJokeService
    {
        Task<IDictionary<int, string>> GetCategories();

        Task<string> GetJoke(string category);

        Task<List<string>> GetMultipleJokes(string category, int n, string firstName, string lastName);
    }
}
