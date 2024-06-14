namespace HelloWebAPI.Models
{
    public class LocalWeatherInfo
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? LocalTime { get; set; }
        public float TemperatureC { get; set; }
        public string? Condition { get; set; }
        public string? Icon { get; set; }
    }
}
