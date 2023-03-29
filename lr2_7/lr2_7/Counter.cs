public class Counter
{
    public int CurrentStatus { get; set; }

    public Counter(int currentStatus)
    {
        CurrentStatus = currentStatus;
    }
    public Counter()
    {
        CurrentStatus = 0;
    }

    public int Increase()
    {
        CurrentStatus = ++CurrentStatus;
        return CurrentStatus;
    }

    public int Decrease()
    {
        CurrentStatus = --CurrentStatus;
        return CurrentStatus;
    }
}