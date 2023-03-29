class Program
{
    static void Main()
    {
        Console.Write("Введите римское число: ");
        String num = Console.ReadLine()!;
        List<int> number = new List<int>(){};
        
        for (int i = 0, j = i; i < num.Length; ++i)
        {
            if (num[i] == 'I')
            {
                number.Add(1);
            }
            if (num[i] == 'V')
            {
                number.Add(5);
            }
            if (num[i] == 'X')
            {
                number.Add(10);
            }
            if (num[i] == 'L')
            {
                number.Add(50);
            }
            if (num[i] == 'C')
            {
                number.Add(100);
            }
            if (num[i] == 'D')
            {
                number.Add(500);
            }
            if (num[i] == 'M')
            {
                number.Add(1000);
            }
        
        }
        
        for (int i = 0; i < num.Length - 1; ++i)
        {
            if (num[i] == 'I' && num[i + 1] == 'V' || num[i + 1] == 'X')
            {
                number.Add(-2);
            }
        
            if (num[i] == 'X' && num[i + 1] == 'C' || num[i + 1] == 'L')
            {
                number.Add(-20);
            }
        
            if (num[i] == 'C' && num[i + 1] == 'M' || num[i + 1] == 'D')
            {
                number.Add(-200);
            }
        }
        Console.Write(number.Sum());
    }
}