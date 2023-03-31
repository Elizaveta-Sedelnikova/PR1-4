using Newtonsoft.Json.Linq;
using WeatherApp.Model;

namespace WeatherApp;

public class ResponseConvert
{
    private MainInfo _main { get; set; }
    private List<Weather> _weather { get; set; } = new();
    private Wind _wind { get; set; }
    private Visability _visability { get; set; }

    public void JsonExctract(JObject? jObject)
    {
        foreach (JToken weather in jObject.SelectToken("weather"))
        {
            _weather.Add(new Weather(weather));
        }

        _wind = new Wind(jObject.SelectToken("wind"));
        List<Wind> winds = new List<Wind>();
        winds.Add(_wind);
        
        _main = new MainInfo(jObject.SelectToken("main"));
        List<MainInfo> mainInfos = new List<MainInfo>();
        mainInfos.Add(_main);

        _visability = new Visability(jObject.SelectToken("visibility"));
        List<Visability> visabilities = new List<Visability>();
        visabilities.Add(_visability);

        ConsoleOutputWeather(_weather, mainInfos, winds, visabilities, 1);
    }
    
    public void JsonExctractForecast(JObject? jObject, int days)
    {
        for (int i = 0; i < days; i++)
        {
            foreach (JToken weather in jObject.SelectToken($"list[{i}].weather"))
            {
                _weather.Add(new Weather(weather));
            }
        }
        
        List<Wind> winds = new List<Wind>();
        for (int i = 0; i < days; i++)
        {
            _wind = new Wind(jObject.SelectToken($"list[{i}].wind"));
            winds.Add(_wind);
        }
        
        List<MainInfo> mainInfos = new List<MainInfo>();
        for (int i = 0; i < days; i++)
        {
            _main = new MainInfo(jObject.SelectToken($"list[{i}].main"));
            mainInfos.Add(_main);
        }

        List<Visability> visabilities = new List<Visability>();
        for (int i = 0; i < days; i++)
        {
            _visability = new Visability(jObject.SelectToken($"list[{i}].visibility"));
            visabilities.Add(_visability);
        }
        

        ConsoleOutputWeather(_weather, mainInfos, winds, visabilities, days);
    }
    

    private void ConsoleOutputWeather(List<Weather> weathers, List<MainInfo> mainInfos, List<Wind> winds, List<Visability> visabilities, int count)
    {

        for (int i = 0; i < count; i++)
        {
            foreach (var value in weathers)
            {
                Console.WriteLine($"Осадки: {value.description}");
                weathers.Remove(value);
                break;
            }
        
            foreach (var value in mainInfos)
            {
                Console.WriteLine($"Температура сейчас: {value.temp}");
                Console.WriteLine($"Ощущается как: {value.feelsLike}");
                Console.WriteLine($"Температура минимальная: {value.tempMin}");
                Console.WriteLine($"Температура максимальная: {value.tempMax}");
                mainInfos.Remove(value);
                break;
            }
        
            foreach (var value in winds)
            {
                Console.WriteLine($"Скорость ветра: {value.speed} м/с"); 
                winds.Remove(value);
                break;
            }
        
            foreach (var value in visabilities)
            {
                Console.WriteLine($"Видимость: {value.visibility} метров");
                Console.WriteLine();
                visabilities.Remove(value);
                break;
            }
            
        }
    }
    
}