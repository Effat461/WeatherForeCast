using System;
using System.Collections.Generic;
using WeatherAPI.Entities.Models;

namespace WeatherAPI.DataAccess.Context;

public partial class DailyWeatherReport
{
    public long Id { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Datetime { get; set; }

    public int? DatetimeEpoch { get; set; }

    public double? Tempmax { get; set; }

    public double? Tempmin { get; set; }

    public double? Temp { get; set; }

    public double? Windspeed { get; set; }

    public double? Cloudcover { get; set; }

    
}
