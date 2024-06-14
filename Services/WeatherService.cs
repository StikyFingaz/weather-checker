using System.Text.Json;
using HelloWebAPI.Models;
using Microsoft.Extensions.Options;

namespace HelloWebAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient, IOptions<WeatherApiOptions> options)
        {
            _httpClient = httpClient;
            _apiKey = options.Value.ApiKey;
        }

        public async Task<LocalWeatherInfo> GetWeatherAsync(string location)
        {
            var response = await _httpClient.GetStringAsync(
                $"https://api.weatherapi.com/v1/current.json?q={location}&key={_apiKey}"
            );
            var externalWeather =
                JsonSerializer.Deserialize<ExternalWeatherResponse>(response)
                ?? throw new Exception("Failed to deserialize weather data.");
            var weatherInfo = new LocalWeatherInfo
            {
                Name = externalWeather.location.name,
                Country = externalWeather.location.country,
                LocalTime = externalWeather.location.localtime,
                TemperatureC = externalWeather.current.temp_c,
                Condition = externalWeather.current.condition.text,
                Icon = externalWeather.current.condition.icon
            };

            return weatherInfo;
        }

        public class ExternalWeatherResponse
        {
            public Location location { get; set; } = new Location();
            public CurrentWeather current { get; set; } = new CurrentWeather();

            public class Location
            {
                public string? name { get; set; }
                public string? country { get; set; }
                public string? localtime { get; set; }
            }

            public class CurrentWeather
            {
                public float temp_c { get; set; }
                public WeatherCondition condition { get; set; } = new WeatherCondition();
            }

            public class CurrentLocation
            {
                public string? name { get; set; }
                public string? country { get; set; }
            }

            public class WeatherCondition
            {
                public string? text { get; set; }
                public string? icon { get; set; }
            }
        }
    }
}
