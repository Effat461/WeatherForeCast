using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.DataAccess.Context;
using WeatherAPI.Entities.Models;
using WeatherAPI.Service.Services.Interface;

namespace WeatherAPI.Service.Services.Concrete
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IConfiguration _configuration;
        private WeatherforecasttaskContext _dataContext = new WeatherforecasttaskContext();
        public WeatherForecastService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public GraphDataResponse GetGraphData()
        {
            try
            {
                List<GraphDataResponse> list = new List<GraphDataResponse>();
                GraphDataResponse graphDataResponse = new GraphDataResponse();
                list = (from item in _dataContext.DailyWeatherReports
                        select new GraphDataResponse
                        {
                            Id = item.Id,
                            Temp = item.Temp,
                            Windspeed = item.Windspeed,
                            Country = item.Country,
                            City = item.City,
                            Cloudcover = item.Cloudcover,
                            Datetime = item.Datetime,
                            DatetimeEpoch = item.DatetimeEpoch,
                        }).Distinct().ToList();
                var minTempList = list.MinBy(p => p.Temp);
                var maxWindSpeedList = list.MaxBy(p => p.Windspeed);
                graphDataResponse.lstMinTemperature = new List<GraphDataResponse>();
                graphDataResponse.lstMinTemperature.Add(minTempList);
                graphDataResponse.lstMaxWindSpeed = new List<GraphDataResponse>();
                graphDataResponse.lstMaxWindSpeed.Add(maxWindSpeedList);
                return graphDataResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
