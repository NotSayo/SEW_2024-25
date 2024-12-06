namespace ConsoleApp.KebabThingy;

public class Customer
{
    public SemaphoreSlim Waiting = new SemaphoreSlim(0);
    public SemaphoreSlim IsOccupying = new SemaphoreSlim(0);
    private bool IsOrdering = true;

    public void Run()
    {
        while (IsOrdering)
        {
            Waiting.Wait();
            Order();
            Waiting.Wait();
            Pay();
            Leave();
        }
    }

    private void Order()
    {
        Console.WriteLine("Customer is ordering...");
        Thread.Sleep(2000);
        Console.WriteLine("Customer has ordered!");
        IsOccupying.Release();
    }

    private void Pay()
    {
        Console.WriteLine("Customer is paying...");
        Thread.Sleep(1000);
        Console.WriteLine("Customer has paid!");
        IsOccupying.Release();
    }

    private void Leave()
    {
        IsOrdering = false;
    }
}