namespace ConsoleApp.CraneMachineThingy;

public class Crane
{
    public required string Code { get; set; }
    private string _currentLocation { get; set; } = "storage";

    public List<Machine> Machines { get; set; } = new List<Machine>()
    {
        new() { Code = "Machine A" },
        new() { Code = "Machine B"}
    };

    public void Run()
    {
        foreach (var machine in Machines)
            new Thread(machine.Process).Start();

        while (true)
        {
            if (Machines.Count == 0)
            {
                Thread.Sleep(2000);
                continue;
            }

            foreach (var machine in Machines)
                MoveToMachine(machine.Code);
            MoveToStorage();
            Console.WriteLine("All machines have been processed!");
            Thread.Sleep(2000);
        }
    }

    public void MoveToStorage()
    {
        Console.WriteLine($"Moving crane to storage...");
        Thread.Sleep(1000);
        _currentLocation = "storage";
    }

    public void MoveToMachine(string codeB)
    {
        Console.WriteLine($"Moving crane to {codeB}...");
        Thread.Sleep(1000);
        _currentLocation = codeB;
        var machine = Machines.First(s => s.Code == codeB);
        machine.Processable.Release();
        machine.Working.Wait();
    }


}