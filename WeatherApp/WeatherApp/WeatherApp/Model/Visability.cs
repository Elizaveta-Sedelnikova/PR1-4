using Newtonsoft.Json.Linq;

namespace WeatherApp.Model;

public class Visability
{
    public double visibility { get; set; }

    public Visability(JToken valueData)
    {
        visibility = double.Parse(valueData.ToString());
    }
}