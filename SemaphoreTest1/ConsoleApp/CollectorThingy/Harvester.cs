namespace ConsoleApp.CollectorThingy;

public class Harvester(string code, CollectorManager manager)
{

    public void Run()
    {
        while (true)
        {
            Acknowledge();
            Collect();
            Store();
        }
    }

    public void Acknowledge()
    {
        manager.Collectable.Wait();
        manager.Acknowledged.Release();
    }

    public void Collect()
    {
        Console.WriteLine($"{code} is collecting...");
        Thread.Sleep(3000);
        Console.WriteLine($"{code} has collected!");
    }

    public void Store()
    {
        manager.Storageable.Wait();
        Console.WriteLine($"{code} is storing...");
        Thread.Sleep(1000);
        Console.WriteLine($"{code} has stored!");
        manager.Storageable.Release();
    }
}