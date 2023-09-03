using Repository.Models;
using Repository.Repository;

namespace Repository.Services.WeatherForcastService
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public void Delete(WeatherForecast weatherForecast)
        {
            _weatherForecastRepository.Delete(weatherForecast);
        }

        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastRepository.Get();
        }

        public WeatherForecast GetById(int id)
        {
            return _weatherForecastRepository.GetById(id);
        }

        public void Insert(WeatherForecast weatherForecast)
        {
             _weatherForecastRepository.Insert(weatherForecast);
        }

        public void Update(WeatherForecast weatherForecast)
        {
            _weatherForecastRepository.Update(weatherForecast);
        }

        public void Save()
        {
            _weatherForecastRepository.Save();
        }
    }
}
