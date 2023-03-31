using Newtonsoft.Json.Linq;

namespace WeatherApp.Model;

public class Wind
{
    public string speed { get; set; }

    public Wind(JToken windData)
    {
        speed = windData.SelectToken("speed").ToString();
    }
}