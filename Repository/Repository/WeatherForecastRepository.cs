using Repository.Data;
using Repository.Models;

namespace Repository.Repository
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ApplicationDbContext _db;

        public WeatherForecastRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Delete(WeatherForecast weatherForecast)
        {
            _db.Forecasts.Remove(weatherForecast);
        }

        public IEnumerable<WeatherForecast> Get()
        {
            return _db.Forecasts;
        }

        public WeatherForecast GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(WeatherForecast weatherForecast)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(WeatherForecast weatherForecast)
        {
            throw new NotImplementedException();
        }
    }
}
