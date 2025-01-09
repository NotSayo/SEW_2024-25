namespace ConsoleApp.TrainThingy;

public class TrainController
{
    public List<Trainstation> Trainstations { get; set; }
    public List<Rail> Rails { get; set; }
    public List<Train> Trains { get; set; }

    public TrainController(int trains)
    {
        Trainstations = new List<Trainstation>()
        {
            new(7)
            {
                Name = "Kyoto",
            },
            new(5)
            {
                Name = "Shizuoka",
            },
            new(11)
            {
                Name = "Tokyo",
            }
        };
        Rails = new List<Rail>()
        {
            new()
            {
                Start = Trainstations.First(s => s.Name == "Kyoto").Name,
                End = Trainstations.First(s => s.Name == "Shizuoka").Name,
                AvailableRails = new SemaphoreSlim(3, maxCount:3)
            },
            new()
            {
                Start = Trainstations.First(s => s.Name == "Shizuoka").Name,
                End = Trainstations.First(s => s.Name == "Tokyo").Name,
                AvailableRails = new SemaphoreSlim(3, maxCount:3),
            }
        };
        Trains = new List<Train>();
        for (int i = 0; i < trains; i++)
            Trains.Add(new () {Name = "Train " + (i+1), Controller = this});
    }

    public void Run()
    {
        foreach (var train in Trains)
            new Thread(train.Run).Start();
    }
}