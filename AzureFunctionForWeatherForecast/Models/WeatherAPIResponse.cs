using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionForWeatherForecast.Models
{
    public class WeatherAPIResponse
    {
        public string datetime { get; set; }
        public int datetimeEpoch { get; set; }
        public double temp { get; set; }
        public double feelslike { get; set; }
        public double humidity { get; set; }
        public double dew { get; set; }
        public double precip { get; set; }
        public double precipprob { get; set; }
        public double snow { get; set; }
        public double snowdepth { get; set; }
        public object preciptype { get; set; }
        public object windgust { get; set; }
        public double windspeed { get; set; }
        public double winddir { get; set; }
        public double pressure { get; set; }
        public double visibility { get; set; }
        public double cloudcover { get; set; }
        public double solarradiation { get; set; }
        public object solarenergy { get; set; }
        public double uvindex { get; set; }
        public string conditions { get; set; }
        public string icon { get; set; }
        public List<string> stations { get; set; }
        public string source { get; set; }
        public string sunrise { get; set; }
        public int sunriseEpoch { get; set; }
        public string sunset { get; set; }
        public int sunsetEpoch { get; set; }
        public double moonphase { get; set; }
    }

    public class Day
    {
        public long Id { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string datetime { get; set; }
        public int datetimeEpoch { get; set; }
        public double tempmax { get; set; }
        public double tempmin { get; set; }
        public double temp { get; set; }
        public double feelslikemax { get; set; }
        public double feelslikemin { get; set; }
        public double feelslike { get; set; }
        public double dew { get; set; }
        public double humidity { get; set; }
        public double precip { get; set; }
        public double precipprob { get; set; }
        public double precipcover { get; set; }
        public List<string> preciptype { get; set; }
        public double snow { get; set; }
        public double snowdepth { get; set; }
        public double windgust { get; set; }
        public double windspeed { get; set; }
        public double winddir { get; set; }
        public double pressure { get; set; }
        public double cloudcover { get; set; }
        public double visibility { get; set; }
        public double solarradiation { get; set; }
        public double solarenergy { get; set; }
        public double uvindex { get; set; }
        public double severerisk { get; set; }
        public string sunrise { get; set; }
        public int sunriseEpoch { get; set; }
        public string sunset { get; set; }
        public int sunsetEpoch { get; set; }
        public double moonphase { get; set; }
        public string conditions { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public List<string> stations { get; set; }
        public string source { get; set; }
        public List<Hour> hours { get; set; }
    }

    public class F2053
    {
        public double distance { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int useCount { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public double contribution { get; set; }
    }

    public class Hour
    {
        public string datetime { get; set; }
        public int datetimeEpoch { get; set; }
        public double temp { get; set; }
        public double feelslike { get; set; }
        public double humidity { get; set; }
        public double dew { get; set; }
        public double precip { get; set; }
        public double precipprob { get; set; }
        public double snow { get; set; }
        public double snowdepth { get; set; }
        public List<string> preciptype { get; set; }
        public double windgust { get; set; }
        public double windspeed { get; set; }
        public double winddir { get; set; }
        public double pressure { get; set; }
        public double visibility { get; set; }
        public double cloudcover { get; set; }
        public double solarradiation { get; set; }
        public double? solarenergy { get; set; }
        public double uvindex { get; set; }
        public double severerisk { get; set; }
        public string conditions { get; set; }
        public string icon { get; set; }
        public List<string> stations { get; set; }
        public string source { get; set; }
    }

    public class KFCI
    {
        public double distance { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int useCount { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public double contribution { get; set; }
    }

    public class KOFP
    {
        public double distance { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int useCount { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public double contribution { get; set; }
    }

    public class KRIC
    {
        public double distance { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int useCount { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public double contribution { get; set; }
    }

    public class KW96
    {
        public double distance { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int useCount { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public double contribution { get; set; }
    }

    public class APIResult
    {
        public int queryCost { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string resolvedAddress { get; set; }
        public string address { get; set; }
        public string timezone { get; set; }
        public double tzoffset { get; set; }
        public string description { get; set; }
        public List<Day> days { get; set; }
        public List<object> alerts { get; set; }
        public Stations stations { get; set; }
        public WeatherAPIResponse weatherAPIResponse { get; set; }
    }

    public class Stations
    {
        public KRIC KRIC { get; set; }
        public KFCI KFCI { get; set; }
        public KW96 KW96 { get; set; }
        public F2053 F2053 { get; set; }
        public KOFP KOFP { get; set; }
    }


}
