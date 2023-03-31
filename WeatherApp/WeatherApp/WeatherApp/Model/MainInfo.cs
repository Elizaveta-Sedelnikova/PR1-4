using Newtonsoft.Json.Linq;

namespace WeatherApp.Model;

public class MainInfo
{
    public string temp { get; set; }
    public string feelsLike { get; set; }
    public string tempMin { get; set; }
    public string tempMax { get; set; }

    public MainInfo(JToken jToken)
    {
        temp = jToken.SelectToken("temp").ToString();
        feelsLike = jToken.SelectToken("feels_like").ToString();
        tempMin = jToken.SelectToken("temp_min").ToString();
        tempMax = jToken.SelectToken("temp_max").ToString();
    }
    
}