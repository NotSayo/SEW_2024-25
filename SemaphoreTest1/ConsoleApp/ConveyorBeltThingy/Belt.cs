namespace ConsoleApp.ConveyorBeltThingy;

public class Belt
{
    public SemaphoreSlim MachineAAvailable { get; set; } = new SemaphoreSlim(0);
    public SemaphoreSlim MachineBAvailable { get; set; } = new SemaphoreSlim(0);
    public SemaphoreSlim BeltPushAvailable { get; set; } = new SemaphoreSlim(2);
    public List<Thingy> Thingies { get; set; } = new List<Thingy>();

    public Belt()
    {
        MachineA a = new MachineA() { Belt = this };
        MachineB b = new MachineB() { Belt = this };
        new Thread(a.Run).Start();
        new Thread(b.Run).Start();
    }

    public void Run()
    {
        while (true)
        {
            BeltPushAvailable.Wait();
            BeltPushAvailable.Wait();
            MoveBelt();
        }
    }

    public void MoveBelt()
    {
        if(Thingies.Count(s => s.Location == "Unprocessed") == 0)
            Thingies.Add(new Thingy());
        foreach (var thingy in Thingies)
            thingy.Move();

        if (Thingies.Count(s => s.Location == "Machine A") >= 1)
            MachineAAvailable.Release();
        else
            BeltPushAvailable.Release();

        if (Thingies.Count(s => s.Location == "Machine B") >= 1)
            MachineBAvailable.Release();
        else
            BeltPushAvailable.Release();
        Console.WriteLine("Items in \"Lager\" " + Thingies.Count(s => s.Location == "Lager"));
    }
}