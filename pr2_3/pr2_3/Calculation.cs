namespace pr2_3;

public class Calculation
{
    public Calculation(string сalculationLine)
    {
        this.СalculationLine = сalculationLine;
    }

    public string СalculationLine { get; set; }

    public void SetCalculationLin(Calculation Line)
    {
        Console.Write("Введите новое значение: ");
        Line.СalculationLine = Console.ReadLine()!;
        Console.WriteLine($"Новое значение: {Line.СalculationLine}");
    }

    public void SetLastSymbolCalculationLine(Calculation Line)
    {
        Console.Write("Введите символ: ");
        string newSymbol = Console.ReadLine()!;
        Line.СalculationLine += newSymbol;
        Console.Write("Строка с новым символом: ");
        Console.WriteLine(Line.СalculationLine);
    }

    public void GetCalculationLin(Calculation Line)
    {
        Console.Write("Текущая строка: ");
        Console.WriteLine(Line.СalculationLine);
    }

    public void GetLastSymbol(Calculation Line)
    {
        Console.Write("Последний символ в строке: ");
        Console.WriteLine(Line.СalculationLine.Last());
    }
    
    public void DeleteLastSymbol(Calculation Line)
    {
        Console.Write("Удален последний символ: ");
        Line.СalculationLine = Line.СalculationLine[..^1];
        Console.Write(Line.СalculationLine);
    }
}