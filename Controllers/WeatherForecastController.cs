using HelloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public static readonly string[] Summaries =
        [
            "Freezing",
            "Chilling",
            "Bracing",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        ];

        [HttpGet]
        public IEnumerable<WeatherForecast> GetForecast()
        {
            var forecast = Enumerable
                .Range(1, 5)
                .Select(index => new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
                .ToArray();

            return forecast;
        }
    }
}
