using AzureFunctionForWeatherForecast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionForWeatherForecast.Services.Interface
{
    public interface IAzureFunctionService
    {
        void AddRecordToDB(APIResult result, string city, string country);
    }
}
