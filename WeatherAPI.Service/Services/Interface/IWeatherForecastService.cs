using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.DataAccess.Context;
using WeatherAPI.Entities.Models;

namespace WeatherAPI.Service.Services.Interface
{
    public interface IWeatherForecastService
    {
        GraphDataResponse GetGraphData();
    }
}
