using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Services.WeatherForcastService;

namespace Repository.Controllers
{
    [ApiController]
    [Route("api/WeatherForecasts")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IWeatherForecastService weatherForcastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForcastService;
        }

        [HttpGet("GetAll",Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastService.Get();
        }
    }
}