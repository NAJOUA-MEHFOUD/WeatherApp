using WeatherForecastApp.OpenWeatherMap_Model;

namespace WeatherForecastApp.Repositories
{
    public interface IWForecastRepository
    {
        WeatherResponse GetForecast(string city);

    }
}
