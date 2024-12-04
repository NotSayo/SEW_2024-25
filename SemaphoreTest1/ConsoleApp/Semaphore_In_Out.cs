namespace ConsoleApp;

public class Semaphore_In_Out
{
    private static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(2);
    public static void TestSemaphore(int amount)
    {
        for (int i = 1; i < amount + 1; i++)
        {
            new Thread(Enter).Start(i);
        }
    }

    static void Enter(object? id)
    {
        Console.WriteLine($"{id} wants to enter");
        _semaphoreSlim.Wait();
        Console.WriteLine($"{id} is in!");
        Thread.Sleep(1000);
        Console.WriteLine($"{id} is leaving");
        _semaphoreSlim.Release();
    }
}