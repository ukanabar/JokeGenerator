using JokeGenerator.HostedServices;
using JokeGenerator.Interfaces;
using JokeGenerator.Models;
using JokeGenerator.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace JokeGenerator
{
    /// <summary>
    /// Application Extension class created to configure services
    /// and instantiate the host service.
    /// </summary>
    public static class AppExtensions
    {
        #region Public Methods
        /// <summary>
        /// Extension method to configure all the custom services
        /// </summary>
        /// <param name="services">IServiceCollection object</param>
        /// <param name="configuration">IConfiguration object with all the appsetting values.</param>
        /// <returns>IServiceCollection concrete object updated with all the custom services.</returns>
        public static IServiceCollection ConfigureProcessorServices(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);

            services.AddSingleton<AppSettings>(appSettings);

            services.AddHttpClient<INameService, NameService>(configClient =>
            {
                configClient.BaseAddress = new System.Uri(configuration.GetValue<string>("NameServiceData:BaseAddress"));
                configClient.DefaultRequestHeaders.Clear();
                configClient.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<IJokeService, JokeService>(configClient =>
            {
                configClient.BaseAddress = new System.Uri(configuration.GetValue<string>("JokeServiceData:BaseAddress"));
                configClient.DefaultRequestHeaders.Clear();
                configClient.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHostedService<JokesUIService>();
            return services;
        }

        /// <summary>
        /// Extension method to configure the host by injecting middleware components.
        /// </summary>
        /// <param name="hostBuilder">IHostBuilder object to update</param>
        /// <returns>Updated IHostBuilder object</returns>
        public static IHostBuilder ConfigureProcessorHost(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));
            return hostBuilder;
        }
        #endregion
    }
}
