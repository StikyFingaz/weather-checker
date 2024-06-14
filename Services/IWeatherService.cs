using HelloWebAPI.Models;

namespace HelloWebAPI.Services
{
    public interface IWeatherService
    {
        Task<LocalWeatherInfo> GetWeatherAsync(string location);
    }
}
