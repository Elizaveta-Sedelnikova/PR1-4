
using pr2_3;

class Program
{
    static void Main()
    {
        //2_3_1 и 2_3_2
        var workers = new List<Worker>()
        {
            new Worker("Katya", "Antonova", 1002.30, 30),
            new Worker("Anton", "Sergeev", 730.80, 10),
            new Worker("Tanya", "Ryabova", 664.30, 20)
        };
        
        Console.Write("Введите имя сотрудника: ");
        String name = Console.ReadLine()!;
        
        Worker wor = new Worker();
        wor.GetSalary(workers, name);
        
        Worker Denis = new Worker("Denis", "Antonov", 1002.30, 30);
        Worker den = new Worker();
        den.GetSalaryPerson(Denis); 
        
        
        //2_3_3
        
        Console.Write("Введите строку: ");
        String CalculationLine = Console.ReadLine()!;
        Calculation Line = new Calculation(CalculationLine);
        String ask = "";
        
        while (ask != "end")
        {
            Console.Write("\nЧто вы хотите сделать?\n1. Изменить строку\n2. Добавить символ в конец строки\n3. Текущее состояние строки\n4. Последний символ в строке\n5.Удалить последний сивол\nВведите end, чтобы закончить\n");
            ask = Console.ReadLine()!;
            switch (ask)
            {
                case "1": 
                    Line.SetCalculationLin(Line);
                    break;
                case "2":
                    Line.SetLastSymbolCalculationLine(Line);
                    break;
                case "3":
                    Line.GetCalculationLin(Line);
                    break;
                case "4":
                    Line.GetLastSymbol(Line);
                    break;
                case "5":
                    Line.DeleteLastSymbol(Line);
                    break;
                case "end":
                    break;   
                default:
                    Console.WriteLine("Такой функции нет");
                    break;
            }
        }
    }
}





