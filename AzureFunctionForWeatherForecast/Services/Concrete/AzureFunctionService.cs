using AzureFunctionForWeatherForecast.Models;
using AzureFunctionForWeatherForecast.Services.Interface;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.DataAccess.Context;

namespace AzureFunctionForWeatherForecast.Services.Concrete
{
    public class AzureFunctionService : IAzureFunctionService
    {
        public AzureFunctionService()
        {
           
        }

        public void AddRecordToDB(APIResult result, string city, string country) 
        {
            try
            {
                foreach (var item in result.days)
                {
                    using (var context = new WeatherforecasttaskContext())
                    {
                        var dailyReport = new DailyWeatherReport()
                        {
                            //Id = item.Id,
                            Country = country,
                            City = city,
                            Datetime = item.datetime,
                            DatetimeEpoch = item.datetimeEpoch,
                            Tempmax = item.tempmax,
                            Tempmin = item.tempmin,
                            Temp = item.temp,
                            Windspeed = item.windspeed,
                            Cloudcover = item.cloudcover,

                        };
                        context.DailyWeatherReports.Add(dailyReport);

                        context.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
