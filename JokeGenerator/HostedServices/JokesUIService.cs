using JokeGenerator.Interfaces;
using JokeGenerator.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JokeGenerator.HostedServices
{
    /// <summary>
    /// Hosted service for JokesGenerator UI
    /// This method will be called at the application start.
    /// </summary>
    public class JokesUIService : IHostedService, IDisposable
    {

        #region Variables
        private bool disposed = false;
        private readonly ILogger<JokesUIService> logger;
        private readonly INameService nameService;
        private readonly IJokeService jokeService;
        #endregion

        #region Ctor
        public JokesUIService(ILogger<JokesUIService> logger, INameService nameService, IJokeService jokeService)
        {
            this.logger = logger;
            this.nameService = nameService;
            this.jokeService = jokeService;
        }
        #endregion

        #region Methods
        public Task StartAsync(CancellationToken cancellationToken)
        {
            DisplayUI();
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing">
        ///   <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            logger.LogInformation($"Is disposed: {disposed}");
            if (!disposed)
            {
                return;
            }
            logger.LogInformation("Disposing objects");
            disposed = true;
            logger.LogInformation($"Is disposed: {disposed}");
        }


        private void DisplayUI()
        {
            Console.WriteLine("Press I to get instructions.");
            var startKey = GetEnteredKey(Console.ReadKey());
            if (startKey == 'i')
            {
                while (true)
                {
                    DisplayMainMenu();
                    var mainOptionKey = GetEnteredKey(Console.ReadKey());
                    if (mainOptionKey == 'c')
                    {
                        DisplayAndGetCategories();
                    }
                    else if (mainOptionKey == 'r')
                    {
                        DisplayRandomJokesUI();
                    }
                    else if (mainOptionKey == 'x')
                    {
                        continue;
                    }
                }
            }

        }


        private void DisplayMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press c to get categories");
            Console.WriteLine("Press r to get random jokes");
        }

        private void DisplayRandomJokesUI()
        {
            var randomName = new NameData();
            Console.WriteLine();
            Console.WriteLine("Want to use a random name? y/n");
            var yesNoKey = GetEnteredKey(Console.ReadKey());
            if (yesNoKey == 'y')
            {
                randomName = nameService.GetRandomName().Result;
            }
            Console.WriteLine();
            Console.WriteLine("Want to specify a category? y/n");
            var yesNoKey2 = GetEnteredKey(Console.ReadKey());
            if (yesNoKey2 == 'y')
            {
                DisplayJokesAsPerCategory(randomName);
            }
            else
            {
                DisplayJokesAsPerUserInput(string.Empty, randomName);
            }
        }

        private void DisplayJokesAsPerUserInput(string category, NameData randomName)
        {
            Console.WriteLine();
            Console.WriteLine("How many jokes do you want? (1-9) and press enter:");
            int n;
            string result2 = Console.ReadLine();
            while (!Int32.TryParse(result2, out n) || (n > 9 || n < 1))
            {
                Console.WriteLine("Please enter valid number of jokes from (1-9) and press enter:");
                result2 = Console.ReadLine();
            }
            var jokes = jokeService.GetMultipleJokes(category, n, randomName.Name, randomName.SurName).Result;
            jokes.ForEach(x => { Console.WriteLine(x); });
        }

        private void DisplayJokesAsPerCategory(NameData randomName)
        {
            Console.WriteLine();
            Console.WriteLine("Enter category number from displayed categories (1-16) and press enter:");
            var categories = DisplayAndGetCategories();
            int categoryId;
            string result = Console.ReadLine();
            while (!Int32.TryParse(result, out categoryId) || (categoryId > 16 || categoryId < 1))
            {
                Console.WriteLine("Please enter valid categoryId from (1-16) and press enter:");

                result = Console.ReadLine();
            }
            if (categories.ContainsKey(categoryId))
            {
                DisplayJokesAsPerUserInput(categories[categoryId], randomName);
            }
        }
        private char GetEnteredKey(ConsoleKeyInfo consoleKeyInfo)
        {
            char key = 'x';
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.C:
                    key = 'c';
                    break;
                case ConsoleKey.D0:
                    key = '0';
                    break;
                case ConsoleKey.D1:
                    key = '1';
                    break;
                case ConsoleKey.D2:
                    key = '2';
                    break;
                case ConsoleKey.D3:
                    key = '3';
                    break;
                case ConsoleKey.D4:
                    key = '4';
                    break;
                case ConsoleKey.D5:
                    key = '5';
                    break;
                case ConsoleKey.D6:
                    key = '6';
                    break;
                case ConsoleKey.D7:
                    key = '7';
                    break;
                case ConsoleKey.D8:
                    key = '8';
                    break;
                case ConsoleKey.D9:
                    key = '9';
                    break;
                case ConsoleKey.R:
                    key = 'r';
                    break;
                case ConsoleKey.Y:
                    key = 'y';
                    break;
                case ConsoleKey.N:
                    key = 'n';
                    break;
                case ConsoleKey.I:
                    key = 'i';
                    break;
                default:
                    key = 'x';
                    break;
            }
            return key;
        }

        private IDictionary<int, string> DisplayAndGetCategories()
        {
            var categories = jokeService.GetCategories().Result;
            Console.WriteLine();
            foreach (KeyValuePair<int, string> category in categories)
            {
                Console.WriteLine(string.Concat(category.Key, ")", category.Value));
            }
            return categories;
        }


        #endregion
    }
}