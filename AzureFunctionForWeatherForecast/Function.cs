using System;
using System.Diagnostics.Metrics;
using Azure.Core;
using AzureFunctionForWeatherForecast.Models;
using AzureFunctionForWeatherForecast.Services.Interface;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionForWeatherForecast
{
    public class Function
    {
        private readonly ILogger _logger;
        private readonly IAzureFunctionService _azureFunctionService;
        public Function(ILoggerFactory loggerFactory,IAzureFunctionService azureFunctionService)
        {
            _logger = loggerFactory.CreateLogger<Function>();
             _azureFunctionService = azureFunctionService;
        }

        [Function("Function")]
        public async Task Run([TimerTrigger("0 */1 * * * *", RunOnStartup = true)] MyInfo myTimer)
        {
            try
            {
                _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
                List<Country> countries = new List<Country>();
                countries = SetCountryList();
                foreach (var item in countries)
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync(GetURL(item.Name));
                    response.EnsureSuccessStatusCode();
                    var resp = await response.Content.ReadAsStringAsync();
                    var jsonResult = JsonConvert.DeserializeObject(resp).ToString();
                    var result = JsonConvert.DeserializeObject<APIResult>(jsonResult);
                   await InsertRecordToDB(result, item.Name, item.Cities[0].Name);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task InsertRecordToDB(APIResult result,string city,string country) 
        {
            try
            {
                _azureFunctionService.AddRecordToDB(result,city,country);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private List<Country> SetCountryList()
        {
            List<Country> countries = new List<Country>();

            countries.Add(new Country
            {
                Name = "Pakistan",
                Cities = new List<City>()
                      {
                          new City { Name="Islamabad" }
                      }
            });
            countries.Add(new Country
            {
                Name = "Pakistan",
                Cities = new List<City>()
                      {
                          new City { Name="Rawalpindi" }
                      }
            });
            countries.Add(new Country
            {
                Name = "DanMark",
                Cities = new List<City>()
                      {
                          new City { Name="Copenhagen" }
                      }
            });
            countries.Add(new Country
            {
                Name = "Pakistan",
                Cities = new List<City>()
                      {
                          new City { Name="Esbjerg" }
                      }
            });
            countries.Add(new Country
            {
                Name = "Canada",
                Cities = new List<City>()
                      {
                          new City { Name="Toronto" }
                      }
            });
            countries.Add(new Country
            {
                Name = "Canada",
                Cities = new List<City>()
                      {
                          new City { Name="Calgary" }
                      }
            });
            countries.Add(new Country
            {
                Name = "Australia",
                Cities = new List<City>()
                      {
                          new City { Name="Melborne" }
                      }
            });
            countries.Add(new Country
            {
                Name = "Australia",
                Cities = new List<City>()
                      {
                          new City { Name="Sydney" }
                      }
            });
            countries.Add(new Country
            {
                Name = "UK",
                Cities = new List<City>()
                      {
                          new City { Name="Bristol" }
                      }
            });
            countries.Add(new Country
            {
                Name = "UK",
                Cities = new List<City>()
                      {
                          new City { Name="London" }
                      }
            });

            return countries;
        }
        private string GetURL(string city)
        {
            string url = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + city + "?unitGroup=metric&key=KVVGKR36DVDV97WPFW29DNCUQ&contentType=";
            //var request = new HttpRequestMessage(HttpMethod.Get,url);
            return url;
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
