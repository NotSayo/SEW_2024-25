namespace ConsoleApp.HarborThingy;

public class Harbor
{
    public SemaphoreSlim HarborOpen = new SemaphoreSlim(5);
    public SemaphoreSlim UnloadAvailable = new SemaphoreSlim(0);
    public SemaphoreSlim Signalable = new SemaphoreSlim(3);
    public List<Ship> Ships = new List<Ship>();

    public Harbor()
    {
        for(int i = 0; i < 6; i++)
        {
            Ships.Add(new Ship()
            {
                Name = "Ship " + (i+1),
               Harbor = this
            });
        }

        foreach (var ship in Ships)
            new Thread(ship.Run).Start();
    }

    public void Run()
    {
        while (true)
        {
            Signalable.Wait();
            Signal();
        }
    }

    public void Signal()
    {
        UnloadAvailable.Release();
        Console.WriteLine("Signaling a ship Unload.");
    }

}