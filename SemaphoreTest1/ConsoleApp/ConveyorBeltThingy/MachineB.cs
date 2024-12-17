namespace ConsoleApp.ConveyorBeltThingy;

public class MachineB
{
    public required Belt Belt { get; set; }
    public void Run()
    {
        while (true)
        {
            Belt.MachineBAvailable.Wait();
            Process();
        }
    }

    public void Process()
    {
        Console.WriteLine("Machine B processing");
        Thread.Sleep(3000);
        Console.WriteLine("Machine B done");
        Belt.BeltPushAvailable.Release();
    }
}