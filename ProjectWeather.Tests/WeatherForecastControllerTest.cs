using AutoFixture;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Weather.Controllers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Project.Weather.Tests
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public async Task GetWeatherMustReturnOk()
        {
            var fixture = new Fixture() { RepeatCount = 5 };

            var weather = fixture.CreateMany<WeatherForecast>();

            var log = A.Fake<ILogger<WeatherForecastController>>();

            var provider = A.Fake<IWeatherForecastProvider>();
           
            A.CallTo(() => provider.GetWeather()).Returns(weather.AsQueryable());            
            
            var controller = new WeatherForecastController(log, provider);

            var result = await controller.Get() as OkObjectResult;

            var values = result.Value as IQueryable<WeatherForecast>;

            Assert.NotNull(values);

            Assert.IsType<EnumerableQuery<WeatherForecast>>(values);

            Assert.Equal(5, values.Count());
        }

        [Fact]
        public async Task GetWeatherByIdMustReturnOk()
        {
            var fixture = new Fixture();

            var weather = fixture.Create<WeatherForecast>();

            var log = A.Fake<ILogger<WeatherForecastController>>();

            var provider = A.Fake<IWeatherForecastProvider>();

            A.CallTo(() => provider.GetWeatherById(A<int>.Ignored)).Returns(weather);

            var controller = new WeatherForecastController(log, provider);

            var result = await controller.GetWeatherById(1) as OkObjectResult;

            var values = result.Value as WeatherForecast;

            Assert.NotNull(values);

            Assert.IsType<WeatherForecast>(values);
        }
    }
}
