
using WeatherApp;

class Program
{
    static void Main()
    {
        var weatherMethods = new WeatherMethods();
        var responseConvert = new ResponseConvert();

        Console.WriteLine("Введите город: ");
        var city = Console.ReadLine();

        Console.WriteLine("На сколько дней вывести погоду? (от 1 до 10)");
        int days = 0;
        bool success = int.TryParse(Console.ReadLine(), out days);
        
        if (success)
        {
            try
            {
                if (days == 1)
                {
                    responseConvert.JsonExctract(weatherMethods.GetWeather(city));
                }
                else if (days <= 10)
                {
                    responseConvert.JsonExctractForecast(weatherMethods.GetForecast(city, days), days);
                }
                else
                {
                    Console.WriteLine("Количество дней превышает допустимое!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка, возможно город введен не правильно");
            }
        }
        else
        {
            Console.WriteLine("Произошла ошибка, неверные данные!");
        }
    }
}




