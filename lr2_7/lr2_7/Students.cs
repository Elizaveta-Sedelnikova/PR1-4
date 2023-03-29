namespace lr2_7;

public class Students
{
    public Students(string Surname, string DateOfBirth, int GroupNum,int[] Points)
    {
        surname = Surname;
        dateOfBirth = DateOfBirth;
        groupNum = GroupNum;
        points = Points;
    }
    public Students() {}
    public string surname { get; set; }
    public string dateOfBirth { get; set; }
    public int groupNum { get; set; }
    public int[] points { get; set; }
    
    public void ListOfStudens(List<Students> students)
    {
        foreach (var vaStudent in students)
        {
            Console.Write($"\nФамилия: {vaStudent.surname}, Дата рождения: {vaStudent.dateOfBirth}, Номер группы: {vaStudent.groupNum}, Оценки: ");
            foreach (var point in vaStudent.points)
            {
                Console.Write($"{point} ");
            }
        }
    }
    
    public List<Students> SearchStudent(string surname, string dateOfBirth, List<Students> students)
    {
        List<Students> result = new List<Students>();

        var search = students.Where(s => s.surname == surname).Where(s => s.dateOfBirth == dateOfBirth);

        if (search != null)
        {
            foreach (var st in search)
            {
                result.Add(new Students(st.surname, st.dateOfBirth, st.groupNum, st.points));
            }
        }
        else
        {
            Console.WriteLine("Студент не найден!");
            return null;
        }
   

        return result;
    }
    
    public void ChangeInfoStudent(List<Students> students)
    {
        string surname;
        string date;
        string n;
        string newSurname;
        string newDateOfBirth;
        int newNumGroup;
    
        Console.Write
            ("Введите фамилию студента: ");
        surname = Console.ReadLine()!;
        Console.Write("Введите дату рождения студента: ");
        date = Console.ReadLine()!;

        var search = SearchStudent(surname, date, students);
        if (search.Count() != 0)
        {
            Console.WriteLine("Что вы хотите изменить?\n 1. Фамилию\n 2. Дату рождения\n 3. Номер группы");
            n = Console.ReadLine()!;

            if (n == "1")
            {
                Console.WriteLine("Введите новую фамилию: ");
                newSurname = Console.ReadLine()!;

                foreach (var st in search)
                {
                    st.surname = newSurname;
                }
            }
            else if (n == "2")
            {
                Console.WriteLine("Введите новую дату рождения: ");
                newDateOfBirth = Console.ReadLine()!;

                foreach (var st in search)
                {
                    st.dateOfBirth = newDateOfBirth;
                }
            }
            else
            {
                Console.WriteLine("Введите новый номер группы: ");
                newNumGroup = int.Parse(Console.ReadLine()!);

                foreach (var st in search)
                {
                    st.groupNum = newNumGroup;
                }
            }
            foreach (var st in search)
            {
                Console.Write($"\nФамилия: {st.surname}, Дата рождения: {st.dateOfBirth}, Номер группы: {st.groupNum}, Оценки: ");
                foreach (var point in st.points)
                {
                    Console.Write($"{point} ");
                }
            }
        }
        else
        {
            Console.WriteLine("Студент не найден!");
        }

    }
}