using Newtonsoft.Json.Linq;

namespace WeatherApp;

public class WeatherMethods
{
    private HttpService _httpService;

    public WeatherMethods()
    {
        HttpService httpService = new HttpService();
        _httpService = httpService;
    }

    public JObject? GetWeather(string city)
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&lang=ru&units=metric";
        return _httpService.QueryResponse(url);
    }

    public JObject? GetForecast(string city, int daysCount)
    {
        string url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&cnt={daysCount}&units=metric&lang=ru";
        return _httpService.QueryResponse(url);
    }
}