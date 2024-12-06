namespace ConsoleApp.KebabThingy;

public class Employee
{
    public required string Name { get; set; }
    public required EmployeeType Type { get; set; }
    public required KebabShop Shop { get; set; }


    public void Run()
    {
        if (Type is EmployeeType.Cashier)
        {
            while (true)
            {
                TakeOrder();
            }
        }

        if (Type is EmployeeType.Cook)
        {
            while (true)
            {
                PrepareOrder();
            }
        }
    }

    private void TakeOrder()
    {
        Console.WriteLine($"{Name} is waiting");
        Shop.CashierWaiting.Wait();
        Shop.Customer!.Waiting.Release();
        Shop.Customer.IsOccupying.Wait();
        Shop.CookOrder.Release();
        Shop.CashierWaiting.Wait();
        Shop.Customer.Waiting.Release();
        Shop.CustomerHere.Release();
        Shop.Customer.IsOccupying.Wait();
    }

    private void PrepareOrder()
    {
        Shop.CookOrder.Wait();
        Console.WriteLine($"{Name} is preparing the meal...");
        Thread.Sleep(2000);
        Console.WriteLine($"{Name} has finished the meal");
        Shop.CashierWaiting.Release();
    }
}

public enum EmployeeType
{
    Cashier,
    Cook
}