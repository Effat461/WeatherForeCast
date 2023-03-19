using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WeatherAPI.DataAccess.Context;
using WeatherAPI.Entities.Models;
using WeatherAPI.Service.Services.Interface;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController(IWeatherForecastService weatherForecastService) 
        {
            _weatherForecastService= weatherForecastService;
        }

        [Route("/GetGraphData")]
        [HttpGet]
        public JsonResult GetGraphData()
        {
            try
            {
                var lstGraphData = _weatherForecastService.GetGraphData();
                return new JsonResult(lstGraphData) ;
            }
            catch (Exception ex)
            {
                throw ex;
                //return Json(_exceptionService.ControllerException(ex));
            }

        }

    }
}
