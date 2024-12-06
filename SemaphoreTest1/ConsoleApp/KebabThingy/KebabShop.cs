namespace ConsoleApp.KebabThingy;

public class KebabShop
{
    public Customer? Customer { get; set; }
    public List<Employee> Employees { get; set; }


    public SemaphoreSlim CookOrder = new SemaphoreSlim(0);
    public SemaphoreSlim CashierWaiting = new SemaphoreSlim(0);
    public SemaphoreSlim CustomerHere = new SemaphoreSlim(0);
    public KebabShop()
    {
        Employees = new()
        {
            new() {Name="Ali", Shop = this, Type = EmployeeType.Cashier},
            new() {Name="Abdul", Shop = this, Type = EmployeeType.Cook},
            new() {Name="Hakan", Shop = this, Type = EmployeeType.Cook},

        };
    }

    public void Run()
    {
        foreach (var employee in Employees)
            new Thread(employee.Run).Start();
        Console.WriteLine("Store is open");
        while (true)
        {
            Customer = new Customer();
            new Thread(Customer.Run).Start();
            CashierWaiting.Release();
            CustomerHere.Wait();
        }
    }
}