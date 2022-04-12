using Microsoft.AspNetCore.Mvc;
using Swagger.Api.Demo.Models;

namespace Swagger.Api.Demo.Controllers
{
    public class WeatherForecastController : BasePublicController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get All Weather Forecast
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecastDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Create a Weather Forecast
        /// </summary>
        /// <param name="weatherForecastDto"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateWeatherForecast")]
        public IActionResult Create([FromBody] WeatherForecastDto weatherForecastDto)
        {
            return Ok(weatherForecastDto);
        }

        /// <summary>
        /// Update a Weather Forecast
        /// </summary>
        /// <param name="weatherForecastDto"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateWeatherForecast")]
        public IActionResult Update([FromBody] WeatherForecastDto weatherForecastDto)
        {
            return Ok(weatherForecastDto);
        }

        /// <summary>
        /// Delete a Weather Forecast
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete(Name = "DeleteWeatherForecast")]
        public IActionResult Delete(int id)
        {
            return Ok(id);
        }

    }
}