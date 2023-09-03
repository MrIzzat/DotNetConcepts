using Repository.Models;

namespace Repository.Services.WeatherForcastService
{
    public interface IWeatherForecastService
    {

        IEnumerable<WeatherForecast> Get();

        WeatherForecast GetById(int id);

        void Insert(WeatherForecast weatherForecast);

        void Update(WeatherForecast weatherForecast);

        void Delete(WeatherForecast weatherForecast);

        void Save();

    }
}
