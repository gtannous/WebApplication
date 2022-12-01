using Microsoft.AspNetCore.Mvc;

namespace WebApplication2_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(template: "/GetByDate")]
        public IEnumerable<WeatherForecast> GetByDate(DateTime tempDate)
        {
            DateTime dt0 = tempDate;
            return Enumerable.Range(1,1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }



        [HttpPost(template: "/PostWeather_1")]
        public WeatherForecast PostWeather_1(WeatherForecast tmpObject)
        {
            try
            {
                return tmpObject;
                //throw new ArgumentNullException("message");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all Machine types: {ex}");
                return null;
            }
        }


        [HttpPost(template: "/PostWeather")]
        public IActionResult PostWeather(WeatherForecast tmpObject)
        {
            try
            {
                //return Ok(tmpObject);
                throw new ArgumentNullException("message");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all Machine types: {ex}");
                return BadRequest("Error Occurred");
            }
        }

    }
}