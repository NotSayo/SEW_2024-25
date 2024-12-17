namespace ConsoleApp.HarborThingy;

public class Ship
{
    public required Harbor Harbor { get; set; }
    public required string Name { get; set; }
    public void Run()
    {
        Harbor.HarborOpen.Wait();
        Console.WriteLine($"{Name} is in the harbor.");
        Harbor.UnloadAvailable.Wait();
        Unload();
        Harbor.Signalable.Release();
        Console.WriteLine($"{Name} is leaving the harbor.");
        Harbor.HarborOpen.Release();
    }

    public void Unload()
    {
        Console.WriteLine($"{Name} is unloading.");
        Thread.Sleep(3000);
        Console.WriteLine($"{Name} is done unloading.");
    }
}