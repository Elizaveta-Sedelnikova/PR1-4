namespace pr2_3;

public class Worker
{ 
    public Worker(string Name, string Surname, double Rate, int Days)
    {
        name = Name;
        surname = Surname;
        rate = Rate;
        days = Days;
    }
    
    public Worker() {}

    private string name;
    public string Name
    {
        get { return name; }
    }
    private string surname;
    public string Surname
    {
        get { return surname; }
    }
    private double rate;
    public double Rate
    {
        get { return rate; }
    }
    private int days;
    public int Days
    {
        get { return days; }
    }
    
    
    public void GetSalary(List<Worker> workers, String name)
    {
        var search = workers.Where(n => n.name == name);
        foreach (var wor in search)
        {
            Console.Write($"Имя работника: {wor.name}\n Фамилия: {wor.surname}\n Зарплата: {wor.rate *  wor.days}");
        }
    }

    public void GetSalaryPerson(Worker worker)
    {
        Console.Write($"Имя работника: {worker.name}\n Фамилия: {worker.surname}\n Зарплата: {worker.rate * worker.days}");
    }

}