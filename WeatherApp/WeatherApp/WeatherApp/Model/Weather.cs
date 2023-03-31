using Newtonsoft.Json.Linq;

namespace WeatherApp.Model;

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
    
    public Weather(JToken weatherData)
    {
        id = int.Parse(weatherData.SelectToken("id").ToString());
        main = weatherData.SelectToken("main").ToString();
        description = weatherData.SelectToken("description").ToString();
        icon = weatherData.SelectToken("icon").ToString();
    }
}