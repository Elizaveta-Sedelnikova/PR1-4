using Npgsql;
namespace GarageApp;

public class DatabaseRequests
{
    public static void GetTypeCar()
    {
        var querySql = "SELECT name FROM type_car;";

        using var cmd = new NpgsqlCommand(querySql, DataBaseService.GetSqlConnection());
        
        Console.WriteLine("Типы автомобилей:");
        NpgsqlDataReader dataReader = cmd.ExecuteReader();
        
        while (dataReader.Read())
        {
            Console.WriteLine($"Название: {dataReader[0]}");
        }
    }

    public static void AddTypeCar(string name)
    {
        var querySql = $"INSERT INTO type_car(name) VALUES ('{name}');";
        
        using var cmd = new NpgsqlCommand(querySql, DataBaseService.GetSqlConnection());
        
        cmd.ExecuteReader();
        
        Console.WriteLine($"Тип автомобиля: {name} успешно создан!");
    }

    public static void GetDriversAndRoot()
    {
        var querySql = 
            $"SELECT first_name, last_name, birthdate, rc.name FROM driver " +
            $"INNER JOIN driver_rights_category drc on driver.id = drc.id_driver " +
            $"INNER JOIN rights_category rc on rc.id = drc.id_rights_category;";
       
        using var cmd = new NpgsqlCommand(querySql, DataBaseService.GetSqlConnection());
        
        Console.WriteLine("Водители и их права:");
        NpgsqlDataReader dataReader = cmd.ExecuteReader();
        
        while (dataReader.Read())
        {
            Console.WriteLine($"Фамилия: {dataReader[0]}\n" +
                              $"Имя: {dataReader[1]}\n" +
                              $"Дата рождения: {dataReader[2]}\n" +
                              $"Права: {dataReader[3]}");
        }
    }

    public static void AddDriversAndRoots(string fName, string lName, string birthday, string typeRoot)
    {
        var querySql = $"INSERT INTO driver(first_name, last_name, birthdate)" +
                       $"VALUES('{fName}', '{lName}', '{birthday}');" +
                       $"INSERT INTO driver_rights_category(id_driver, id_rights_category)" +
                       $"VALUES((SELECT id FROM driver WHERE driver.last_name = '{lName}'), " +
                       $"(SELECT id FROM rights_category WHERE rights_category.name = '{typeRoot}'))";
        
        using var cmd = new NpgsqlCommand(querySql, DataBaseService.GetSqlConnection());
        cmd.ExecuteReader();
            
        Console.WriteLine($"Водитель {fName} успешно создан!");
    }

    public static void GetCarsAndType()
    {
        var querySql = $"SELECT tc.name ,car.name, state_number, number_passengers FROM car " +
                       $"INNER JOIN type_car tc ON car.id_type_car = tc.id";
        
        using var cmd = new NpgsqlCommand(querySql, DataBaseService.GetSqlConnection());
                
        Console.WriteLine("ТС и их тип:");
        NpgsqlDataReader dataReader = cmd.ExecuteReader();
                
        while (dataReader.Read())
        {
            Console.WriteLine($"Тип: {dataReader[0]}\n" +
                              $"Имя: {dataReader[1]}\n" +
                              $"Гос. номер: {dataReader[2]}\n" +
                              $"Число пассажиров: {dataReader[3]}");
        }
    }
    
    public static void AddCarsAndType(string typeCar, string name, string stateNumber, string numbPassengers, bool carOrType)
    {
        var querySql = " ";
        if (carOrType == false)
        {
            querySql = $"INSERT INTO car(id_type_car, name, state_number, number_passengers)" +
                       $"VALUES((SELECT id FROM type_car WHERE name = '{typeCar}'), '{name}, '{stateNumber}','{numbPassengers});";
        }
        else
        {
            querySql = $"INSERT INTO type_car(name) VALUES('{typeCar}'); " +
                       $"INSERT INTO car(id_type_car, name, state_number, number_passengers) " +
                       $"VALUES((SELECT id FROM type_car WHERE name = '{typeCar}'), '{name}', '{stateNumber}', '{numbPassengers}');";
        }
        using var cmd = new NpgsqlCommand(querySql, DataBaseService.GetSqlConnection());
        cmd.ExecuteReader();
            
        Console.WriteLine($"ТС {name} успешно создано!");
    }
    
    public static void GetRoute()
    {
        var querySql = $"SELECT d.last_name, c.name, i.name, route.number_passengers FROM route " +
                       "INNER JOIN car c on c.id = route.id_car " +
                       "INNER JOIN driver d on d.id = route.id_driver " +
                       "INNER Join itinerary i on i.id = route.id_itinerary;";
        
        using var cmd = new NpgsqlCommand(querySql, DataBaseService.GetSqlConnection());
                
        Console.WriteLine("Поездки:");
        NpgsqlDataReader dataReader = cmd.ExecuteReader();
                
        while (dataReader.Read())
        {
            Console.WriteLine($"Водитель: {dataReader[0]}\n" +
                              $"ТС: {dataReader[1]}\n" +
                              $"Рейс: {dataReader[2]}\n" +
                              $"Число пассажиров: {dataReader[3]}");
        }
    }

    public static void AddRoute(string driverName, string carName, string itenenaryName, int numPassengers)
    {
        var querySql = $"INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) " +
                       $"VALUES((SELECT id FROM driver WHERE last_name = '{driverName}'), " +
                       $"(SELECT id FROM car WHERE name = '{carName}'), " +
                       $"(SELECT id FROM itinerary WHERE name = '{itenenaryName}'), {numPassengers});";
        
        using var cmd = new NpgsqlCommand(querySql, DataBaseService.GetSqlConnection());
        cmd.ExecuteReader();
            
        Console.WriteLine("Поездка успешно создан!");
    }

    public static void GetItinerary()
    {
        var querySql = $"SELECT name FROM itinerary;";
        
        using var cmd = new NpgsqlCommand(querySql, DataBaseService.GetSqlConnection());
                
        Console.WriteLine("Маршруты:");
        NpgsqlDataReader dataReader = cmd.ExecuteReader();
                
        while (dataReader.Read())
        {
            Console.WriteLine($"Название: {dataReader[0]}");
        }
    }

    public static void AddItinerary(string name)
    {
        var querySql = $"INSERT INTO itinerary(name)" +
                            $"VALUES('{name}');";
            
        using var cmd = new NpgsqlCommand(querySql, DataBaseService.GetSqlConnection());
        cmd.ExecuteReader();
            
        Console.WriteLine($"Маршрут {name} успешно создан!");
    }
    
}
