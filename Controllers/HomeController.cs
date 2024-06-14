using HelloWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private readonly IWeatherService _weatherSerice;

        public HomeController(IWeatherService weatherService)
        {
            _weatherSerice = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather(string location)
        {
            var weatherInfo = await _weatherSerice.GetWeatherAsync(location);
            return Ok(weatherInfo);
        }
    }
}
