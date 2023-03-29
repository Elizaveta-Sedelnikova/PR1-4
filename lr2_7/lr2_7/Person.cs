namespace lr2_7;

public class Person
{
    public  string name { get; }
    public  int age { get; }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public Person()
    {
        name = "Elizaveta";
        age = 18;
    }

    ~Person()
    {
        Console.WriteLine($"{name} has deleted");
    }
}