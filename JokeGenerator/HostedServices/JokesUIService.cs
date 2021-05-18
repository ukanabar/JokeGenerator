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
    public class JokesUIService : IHostedService, IDisposable
    {
        
        #region Private Variables
        private bool disposed = false;
        private readonly ILogger<JokesUIService> logger;
        private readonly INameService nameService;
        #endregion

        #region Constructor
        public JokesUIService(ILogger<JokesUIService> logger, INameService nameService)
        {
            this.logger = logger;
            this.nameService = nameService;
        }
        #endregion

        #region Methods
        public Task StartAsync(CancellationToken cancellationToken)
        {
            DisplayUI();
            return Task.CompletedTask;
        }

        private async void DisplayUI()
        {
            Console.WriteLine("UI displayed.");
            string name = await nameService.GetRandomName();
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
            if (disposed)
            {
                return;
            }
            logger.LogInformation("Disposing objects");
            disposed = true;
            logger.LogInformation($"Is disposed: {disposed}");
        }
        #endregion
    }
}