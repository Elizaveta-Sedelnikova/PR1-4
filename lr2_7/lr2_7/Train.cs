namespace lr2_7;

public class Train
{
    public Train(string Destination, int TrainNumber, string DepartureTime)
    {
        destination = Destination;
        trainNumber = TrainNumber;
        departureTime = DepartureTime;
    }
    public Train(){}

    public string destination { get; set; }
    public int trainNumber { get; set; }
    public string departureTime { get; set; }
    
    public void ListOfTrain(List<Train> train)
    {
        foreach (var element in train)
        {
            Console.Write($"\nНазвание пункта назначения: {element.destination}, номер поезда: {element.trainNumber}, время отправления: {element.departureTime}");
        }
    }

    public List<Train> InfoAboutTrain(int trainNumber, List<Train> train)
    {
        List<Train> result = new List<Train>();

        var search = train.Where(s => s.trainNumber == trainNumber);

        if (search != null)
        {
            foreach (var element in search)
            {
                result.Add(new Train(element.destination, element.trainNumber, element.departureTime));
            }
        }
        else
        {
            Console.WriteLine("Поезд не найден!");
            return null;
        }
        return result;
    }
}