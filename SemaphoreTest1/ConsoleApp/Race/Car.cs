namespace ConsoleApp.Race;

public class Car
{
    public required RaceController Controller { get; set; }
    public required string Name { get; set; }
    public void Run()
    {
        Thread.Sleep(1000);
        StartRace();
        PitStop();
        FinishRace();

    }

    private void StartRace()
    {
        Controller.RaceStartCondition.Release();
        Controller.RaceStarted.Wait();
        Console.WriteLine(Name + " started");
        Thread.Sleep(5000);
    }

    private void PitStop()
    {
        Controller.PitOpen.Wait();
        Console.WriteLine("Pitstop for " + Name);
        Thread.Sleep(3000);
        Controller.PitOpen.Release();
    }

    public void FinishRace()
    {
        Controller.RaceFinish.Release();
        Console.WriteLine(Name + " finished");
    }
}