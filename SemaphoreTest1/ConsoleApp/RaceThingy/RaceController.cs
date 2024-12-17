namespace ConsoleApp.RaceThingy;

public class RaceController
{
    public SemaphoreSlim RaceStartCondition = new SemaphoreSlim(0);
    public SemaphoreSlim RaceStarted = new SemaphoreSlim(0);
    public SemaphoreSlim PitOpen = new SemaphoreSlim(3);
    public SemaphoreSlim RaceFinish = new SemaphoreSlim(0);
    private List<Car> Cars { get; set; }

    public void Run()
    {
        InitCars();
        for(int i = 0; i < Cars.Count; i++)
            RaceStartCondition.Wait();
        Console.WriteLine("Race Started!");
        RaceStarted.Release(Cars.Count);
        for(int i = 0; i < Cars.Count; i++)
            RaceFinish.Wait();
        Console.WriteLine("Race Finished");
    }

    public RaceController()
    {
        Cars = new List<Car>()
        {
            new() { Name = "Car 1", Controller = this },
            new() { Name = "Car 2", Controller = this },
            new() { Name = "Car 3", Controller = this },
            new() { Name = "Car 4", Controller = this },
            new() { Name = "Car 5", Controller = this },
        };
    }

    public void InitCars()
    {
        foreach (var car in Cars)
            new Thread(car.Run).Start();
    }
}