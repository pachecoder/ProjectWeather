using System.Linq;
using System.Threading.Tasks;

namespace Project.Weather
{
    public interface IWeatherForecastProvider
    {
        Task<WeatherForecast> GetWeatherById(int id);

        Task<IQueryable<WeatherForecast>> GetWeather();
    }
}
