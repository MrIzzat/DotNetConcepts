using ORM.Models;

namespace ORM.Services.WeatherForecastService
{
    public interface IWeatherForecastService
    {

        IEnumerable<WeatherForecast> Get();
    }
}
