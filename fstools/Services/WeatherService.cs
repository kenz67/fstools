using fstools.Models;

namespace fstools.Services
{
    public class WeatherService
    {
        public String CurrentIcao { get; set; }
        public WeatherInfo CurrentWeather { get; set; } = null;
    }
}
