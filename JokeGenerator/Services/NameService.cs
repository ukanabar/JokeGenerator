using JokeGenerator.Interfaces;
using JokeGenerator.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JokeGenerator.Services
{
    public class NameService: INameService
    {
        #region fields
        private readonly HttpClient httpClient;
        private readonly ILogger<NameService> logger;
        private readonly AppSettings appSettings;
        #endregion


        #region ctor
        public NameService(HttpClient httpClient, ILogger<NameService> logger,
                        AppSettings appSettings)
        {
            this.httpClient = httpClient;
            this.logger = logger;
            this.appSettings = appSettings;           
        }
        #endregion

        #region Methods
        public async Task<NameData> GetRandomName()
        {
            var nameData = new NameData();
            try
            {
                var streamTask = httpClient.GetStreamAsync(appSettings.nameServiceData.Path);
                nameData = await JsonSerializer.DeserializeAsync<NameData>(await streamTask);                
            } 
            catch(Exception ex)
            {
                //log and eat the exception and return empty name
                logger.LogError(string.Format("Exception Occurred While Generating Random Name: Message={0} ", ex.Message));
            }
            return nameData;         
        }
        #endregion

    }
}
