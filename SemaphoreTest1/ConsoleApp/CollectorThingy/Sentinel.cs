namespace ConsoleApp.CollectorThingy;

public class Sentinel(string code, CollectorManager manager)
{


    public void Run()
    {
        while (true)
        {
            Scan();
            Found();
        }
    }

    public void Scan()
    {
        Console.WriteLine($"{code} is scanning...");
        Thread.Sleep(2000);
    }

    public void Found()
    {
        Console.WriteLine($"{code} found something!");
        manager.Collectable.Release();
        manager.Acknowledged.Wait();
    }
}