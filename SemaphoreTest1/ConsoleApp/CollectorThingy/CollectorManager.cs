namespace ConsoleApp.CollectorThingy;

public class CollectorManager
{
    public SemaphoreSlim Collectable = new SemaphoreSlim(0);
    public SemaphoreSlim Acknowledged = new SemaphoreSlim(0);
    public SemaphoreSlim Storageable = new SemaphoreSlim(2);

    public List<Harvester> Harvesters;
    public List<Sentinel> Sentinels;

    public CollectorManager()
    {
        Harvesters = new()
        {
            new Harvester("HX_1", this),
            new Harvester("HX_2", this),
            new Harvester("HX_3", this),
            new Harvester("HX_4", this)
        };
        Sentinels = new()
        {
            new Sentinel("SX_1", this),
            new Sentinel("SX_2", this),
        };

        foreach (var sentinel in Sentinels)
            new Thread(sentinel.Run).Start();

        foreach (var harvester in Harvesters)
            new Thread(harvester.Run).Start();
    }
}