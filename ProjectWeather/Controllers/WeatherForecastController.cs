using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Weather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IWeatherForecastProvider provider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastProvider provider)
        {
            _logger = logger;

            this.provider = provider;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(WeatherForecast))]
        public async Task<IActionResult> GetWeatherById(int id)
        {
            var weather = await provider.GetWeatherById(id);

            return Ok(weather);
        }

        [HttpGet("List")]
        [ProducesResponseType(200, Type = typeof(IQueryable<WeatherForecast>))]
        public async Task<IActionResult> Get()
        {
            var weather = await provider.GetWeather();

            return Ok(weather);
        }
    }
}
