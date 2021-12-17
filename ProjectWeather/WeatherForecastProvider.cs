using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Weather
{
    public class WeatherForecastProvider : IWeatherForecastProvider
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast> GetWeatherById(int id)
        {
            var rng = new Random();

            return Task.FromResult(
                    Enumerable.Range(1, 5)
                    .Select(index => new WeatherForecast
                    {
                        Id = index,
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    }).FirstOrDefault(s => s.Id == id)
                );
        }

        public Task<IQueryable<WeatherForecast>> GetWeather()
        {
            var rng = new Random();

            return Task.FromResult(
                    Enumerable.Range(1, 5)
                    .Select(index => new WeatherForecast
                    {
                        Id = index,
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    }).AsQueryable()
                ); ;
        }
    }
}
