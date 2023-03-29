
using lr2_7;

class Program
{
    static void Main()
    {
        //2_2_1
        var students = new List<Students>()
        {
            new Students("Петров", "13.12.2003", 621, new []{2, 3, 5, 4, 2}),
            new Students("Рыбалкин", "01.12.2003", 604, new []{4, 4, 4, 4, 5}),
            new Students("Рябова", "08.02.2005", 612, new []{5, 5, 4, 5, 5}),
            new Students("Антонов", "10.03.2005", 712, new []{2, 2, 3, 3, 5}),
            new Students("Федоров", "28.02.2002", 812, new []{3, 5, 4, 2, 5})
        };
        
        Console.WriteLine("Что вы хотите сделать\n 1. Вывести список всех студентов\n 2. Изменить фамилию, дату рождения или номер группы студента\n 3. Найти студента по фамилии и дате рождения");
        int num = int.Parse(Console.ReadLine());
        
        switch (num)
        {
            case 1:
                Students ListSt = new Students();
                ListSt.ListOfStudens(students);
                break;
            case 2:
                Students Change = new Students();
                Change.ChangeInfoStudent(students);
                
                break;
            case 3:
                string surname, date;
                Console.Write("Введите фамилию студента: ");
                surname = Console.ReadLine()!;
                Console.Write("Введите дату рождения студента: ");
                date = Console.ReadLine()!;
                Students search = new Students();
                var result = search.SearchStudent(surname, date, students);
                if (result.Count == 0)
                {
                    Console.WriteLine("Такого студента не существует");
                }
                else
                {
                    foreach (var res in result)
                    {
                        Console.Write($"\nФамилия: {res.surname}, Дата рождения: {res.dateOfBirth}, Номер группы: {res.groupNum}, Оценки: ");
                        foreach (var point in res.points)
                        {
                            Console.Write($"{point} ");
                        }
                    }
                }
                break;
            default:
                Console.Write("Такой функции не существует");
                break;
        }


        //2_2_2
        var train = new List<Train>()
        {
            new Train("Томск", 156, "10:00"),
            new Train("Новосибирск", 243, "12:00"),
            new Train("Кемерово", 646, "08:30"),
            new Train("Асино", 786, "13:00"),
            new Train("Омск", 537, "09:30")
        };
        
        Console.Write("Что вы хотите сделать?\n 1. Вывести информацию о поезде\n 2. Вывести список поездов\nВведите номер функции: ");
        int numb = int.Parse(Console.ReadLine()!);
        
        switch (numb)
        {
            case 1:
                Console.Write("Введите номер поезда: ");
                int trainNumber = int.Parse(Console.ReadLine()!);
                Train numberTr = new Train();
                var result = numberTr.InfoAboutTrain(trainNumber, train);
                if (result.Count() == 0)
                {
                    Console.WriteLine("Такого поезда нет!");
                }
                else
                {
                    foreach (var el in result)
                    {
                        Console.WriteLine($"Пункт назначения: {el.destination}, номер поезда: {el.trainNumber}, время отправления: {el.departureTime}");
                    }
                }
                break;
            case 2:
                Train ListTr = new Train();
                ListTr.ListOfTrain(train);
                break;
            default:
                Console.Write("Такой функции не существует");
                break;
        }


        //2_2_3
        Console.Write("\nВведите первое число: ");
        int n1 = int.Parse(Console.ReadLine()!);
        Console.Write("Введите второе число: ");
        int n2 = int.Parse(Console.ReadLine()!);
        Console.Write("\n 1. Вывести введенные числа\n 2. Изменить числа\n3.Вывести сумму\n4. Вывести наибольшее число\nЧто вы хотите сделать?");
        int number = int.Parse(Console.ReadLine()!);
        
        switch (number)
        {
            case 1:
                IntNums print = new IntNums();
                print.Print(n1, n2);
                break;
            case 2:
                IntNums cheange = new IntNums();
                Tuple<int, int> res = cheange.changeNum(n1, n2);
                n1 = res.Item1;
                n2 = res.Item2;
                Console.WriteLine($"Обновленные числа первое = {n1}, второе = {n2}");
                break;
            case 3:
                IntNums sum = new IntNums();
                sum.Summa(n1, n2);
                break;
            case 4:
                IntNums max = new IntNums();
                max.max(n1, n2);
                break;
        }


        //2_2_4
        Console.Write("Введите начальное значение счетчика (либо '0' для установки по умолчанию: ");
        int start = int.Parse(Console.ReadLine()!);
        
        Counter counter = start == 0 ? new Counter() : new Counter(start);
        
        string ask = "";
        
        while (ask != "end")
        {
            Console.Write("\n\nВыберите действие: '++' - увеличить, '--' - уменьшить, 'cur' - текущее состояние. Закончить - 'end'\n\tДействие: ");
            ask = Console.ReadLine()!;
            switch (ask)
            {
                case "++":
                    counter.Increase();
                    break;
                case "--":
                    counter.Decrease();
                    break;
                case "cur":
                    Console.WriteLine($"\nТекущее состояние: {counter.CurrentStatus}");
                    break;
                case "end":
                    break;
                default:
                    Console.WriteLine("Ошибка");
                    break;
            }
        }


        //2_2_5
        Person object_Class = new Person();
        Console.WriteLine(object_Class.name);
        
        Person object_Class_2 = new Person("Nikita", 19);
        Console.WriteLine(object_Class_2.name);
        
        GC.Collect();   
    }
}

