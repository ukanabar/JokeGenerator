using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator.Interfaces
{
    public interface INameService
    {
        Task<string> GetRandomName();
    }
}
