using Repository.Models;

namespace Repository.Services.WeatherForcastService
{
    public class WeatherForecastServiceExtended : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public void Delete(WeatherForecast weatherForecast)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 50).Select(index => new WeatherForecast
            {
                Date = (DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
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
