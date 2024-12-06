namespace ConsoleApp.CraneMachineThingy;

public class Machine
{
    public required string Code { get; set; }
    public SemaphoreSlim Processable = new SemaphoreSlim(0);
    public SemaphoreSlim Working = new SemaphoreSlim(0);

    public void Process()
    {
        while (true)
        {
            Processable.Wait();
            Console.WriteLine($"{Code} is processing...");
            Thread.Sleep(2000);
            Console.WriteLine($"{Code} has processed!");
            Working.Release();
        }
    }
}