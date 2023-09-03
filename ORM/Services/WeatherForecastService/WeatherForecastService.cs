using ORM.Data;
using ORM.Models;

namespace ORM.Services.WeatherForecastService
{
    public class WeatherForecastService : IWeatherForecastService
    {
       
        private readonly ApplicationDbContext _db;

        public WeatherForecastService(ApplicationDbContext db)
        {
           _db = db;
        }
        public IEnumerable<WeatherForecast> Get()
        {
            return _db.Forecasts;
        }
    }
}
