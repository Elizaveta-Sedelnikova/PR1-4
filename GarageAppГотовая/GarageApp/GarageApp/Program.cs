using GarageApp;

class Program
{
    static void Main()
    {
        int number = 0;
        Console.WriteLine("1. Получить типы автомобилей\n2. Добавить тип автомобилей\n3. Получить водителей и их права\n4. Добавить водителя и его права\n5. Получить автомобили и их тип\n6. Добавить автомобиль и и его тип\n7. Получить поездки\n8. Добавить поездку\n9. Получить маршруты\n10. Добавить маршрут");
        bool success = int.TryParse(Console.ReadLine(), out number);

        if (success)
        {
            switch (number)
            {
                case 1:
                    DatabaseRequests.GetTypeCar();
                    break;
                case 2:
                    var input = " ";
                    Console.WriteLine("Введите название типа: ");
                    input = Console.ReadLine();
                    if (input != null)
                    {
                        try
                        {
                            DatabaseRequests.AddTypeCar(input);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Ошибка: {e}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Поле 'Наименование' не заполнено!");
                    }
                    break;
                case 3:
                    DatabaseRequests.GetDriversAndRoot();
                    break;
                case 4:
                    Console.WriteLine("Введите имя водителя: ");
                    var fName = Console.ReadLine();
                    Console.WriteLine("Введите фамилию водителя: ");
                    var lName = Console.ReadLine();
                    Console.WriteLine("Введите дату рождения (формат: год-месяц-день): ");
                    var birthday = Console.ReadLine();
                    Console.WriteLine("Введите тип прав водителя: ");
                    var tRoot = Console.ReadLine();
                    try
                    {
                            DatabaseRequests.AddDriversAndRoots(fName, lName, birthday, tRoot);
                    }
                    catch (Exception e)
                    {
                            Console.WriteLine($"Ошибка: {e}");
                    }
                    break;
                case 5:
                    DatabaseRequests.GetCarsAndType();
                    break;
                case 6:
                    bool typeParse;
                    Console.WriteLine("Введите тип авто: ");
                    var type = Console.ReadLine();
                    Console.WriteLine("Введите наименование: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Введите гос. номер: ");
                    var stateNumber = Console.ReadLine();
                    Console.WriteLine("Введите число мест: ");
                    var numberPasrs = Console.ReadLine();
                    Console.WriteLine("Новый тип авто? (true or false): ");
                    var newType = Console.ReadLine();
                    bool statusParse = bool.TryParse(newType, out typeParse);
                    if (statusParse)
                    {
                        try
                        {
                            DatabaseRequests.AddCarsAndType(type, name, stateNumber,numberPasrs, typeParse);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Ошибка: {e}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверные входные данные!");
                    }
                    break;
                case 7:
                    DatabaseRequests.GetRoute();
                    break;
                case 8:
                    int numParse;
                    Console.WriteLine("Введите фамилию водителя: ");
                    var lNameDriver = Console.ReadLine();
                    Console.WriteLine("Введите наименование авто: ");
                    var nameCar = Console.ReadLine();
                    Console.WriteLine("Введите маршрут: ");
                    var itineraryName = Console.ReadLine();
                    Console.WriteLine("Введите количество пассажиров: ");
                    var countPassengers = Console.ReadLine();
                    bool statusPasreInt = int.TryParse(countPassengers, out numParse);
                    if (statusPasreInt)
                    {
                        try
                        {
                            DatabaseRequests.AddRoute(lNameDriver, nameCar, itineraryName, numParse);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Ошибка: {e}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверные входные данные!");
                    }
                    break;
                case 9:
                    DatabaseRequests.GetItinerary();
                    break;
                case 10:
                    Console.WriteLine("Введите наименование маршрута: ");
                    var nameItinerary = Console.ReadLine();
                    try
                    {
                        DatabaseRequests.AddItinerary(nameItinerary);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка: {e}");
                    }
                    break;
                default:
                    Console.WriteLine("Такой функции нет!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Неверные данные!");
        }

    }
}






