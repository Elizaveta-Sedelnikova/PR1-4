
class Program 
{
    static void Main()
    {
        //2.1.1
        Console.Write("Введите первую строку: ");
        string j = Console.ReadLine()!;
        Console.Write("Введите вторую строку: ");
        string s = Console.ReadLine()!;
        int count = 0;
        for (int i = 0; i < j.Length; ++i)
        {
            for (int k = 0; k < s.Length; ++k)
            {
                if (j[i] == s[k])
                {
                    count++;
                }
            }
        }
        Console.WriteLine(count);
        
        
        //2.1.2
        int[] candidates1 = { 2, 5, 2, 1, 2, 8, 4, 1 };
        int target = 5;
        var result = CombinationSum(candidates1, target);
        
        foreach (var el in result)
        {
            foreach (var el1 in el)
            {
                Console.Write($"[{el1}] ");
            }
            Console.WriteLine();
        }
        
        List<List<int>> CombinationSum(int[] candidates, int target)
        {
          Array.Sort(candidates);
          return CombinationSumHelper(candidates, target, 0);
        }
        
        List<List<int>> CombinationSumHelper(int[] candidates, int target, int start)
        {
          List<List<int>> result = new List<List<int>>();
        
          for (int i = start; i < candidates.Length && candidates[i] <= target; i++)
          {
              if (i > start && candidates[i] == candidates[i - 1])
              {
                  continue;
              }
              foreach (List<int> combination in CombinationSumHelper(candidates, target - candidates[i], i + 1))
              {
                  combination.Insert(0, candidates[i]);
                  result.Add(combination);
              }
          }
          return result;
        }
             
        
        //2.1.3
        int[] numbers = new int[] {1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        int count1 = 0;
        bool flag = false;
        for (int i = 0; i < numbers.Length; ++i)
        {
            for (int k = 0; k < numbers.Length - 1; ++k)
            {
                if (i == k)
                {
                    k++;
                }
                if (numbers[i] == numbers[k])
                {
                    count1++;
                }
            }
            Console.Write($"{numbers[i]} ");
        }
        
        if (count1 >= 2)
        {
            flag = true;
        }
        Console.WriteLine(flag);
    }
}

