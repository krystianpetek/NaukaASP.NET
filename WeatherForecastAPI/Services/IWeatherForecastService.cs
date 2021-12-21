using System.Collections.Generic;

namespace CwiczenieAPI.Services
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> Get();
        public IEnumerable<WeatherForecast> GetGenerate(int liczbaRezultatow, int min, int max);
    }
}
