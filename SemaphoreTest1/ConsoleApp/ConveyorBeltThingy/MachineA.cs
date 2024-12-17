using System.Diagnostics;

namespace ConsoleApp.ConveyorBeltThingy;

public class MachineA
{
    public required Belt Belt { get; set; }

    public void Run()
    {
        while (true)
        {
            Belt.MachineAAvailable.Wait();
            Process();
        }
    }

    public void Process()
    {
        Console.WriteLine("Machine A processing");
        Thread.Sleep(2000);
        Console.WriteLine("Machine A done");
        Belt.BeltPushAvailable.Release();
    }
}