using System.Diagnostics;
using System.Text;

namespace ConsoleApp.Heist;

public class Heist
{
    private Lock LogLock { get; set; } = new();
    public StringBuilder Log { get; set; } = new StringBuilder();

    public void Run()
    {
        var sw = new Stopwatch();
        sw.Start();

        AggregateLog("Task 1");

        Task.WhenAll(
            Task.Run(() => AggregateLog(HireCrew())),
            Task.Run(() => AggregateLog(GetBankPlans())),
            Task.Run(() => AggregateLog(BribeBankEmployee())),
            Task.Run(() => AggregateLog(BuyGetawayCar()))
        ).GetAwaiter().GetResult();

        AggregateLog("Task 2");

        Task.WhenAll(
            Task.Run(() => AggregateLog(EnterBank()))
        ).GetAwaiter().GetResult();

        AggregateLog("Task 3");

        Task.WhenAll(
            Task.Run(() => AggregateLog(RobCounter1())),
            Task.Run(() => AggregateLog(RobCounter2())),
            Task.Run(() => AggregateLog(RobCounter3()))
        ).GetAwaiter().GetResult();

        AggregateLog("Task 4");

        Task.WhenAll(
            Task.Run(() => AggregateLog(LeaveBank()))
        ).GetAwaiter().GetResult();

        AggregateLog("Task 5");

        Task.WhenAll(
            Task.Run(() => AggregateLog(LoosePolice()))
        ).GetAwaiter().GetResult();

        sw.Stop();
        Console.WriteLine("Time: " + sw.ElapsedMilliseconds / 1000.0 + "s");
        Console.WriteLine("Log:");
        Console.WriteLine(Log.ToString());
    }

    private void AggregateLog(string message)
    {
        lock (LogLock)
        {
            Log.AppendLine(message);
        }
    }


    Func<string> BribeBankEmployee = () => {
        Thread.Sleep(300);
        return ELog.BRIBE_BANK_EMPLOYEE.ToString();
    };

    Func<string> BuyGetawayCar = () => {
        Thread.Sleep(200);
        return ELog.BUY_GETAWAY_CAR.ToString();
    };

    Func<string> GetBankPlans = () => {
        Thread.Sleep(200);
        return ELog.GET_BANK_PLAN.ToString();
    };

    Func<string> HireCrew = () => {
        Thread.Sleep(300);
        return ELog.HIRE_CREW.ToString();
    };

    Func<string> EnterBank = () => {
        Thread.Sleep(100);
        return ELog.ENTER_BANK.ToString();
    };

    Func<string> RobCounter1 = () => {
        Thread.Sleep(300);
        return ELog.ROB_COUNTER_1.ToString();
    };

    Func<string> RobCounter2 = () => {
        Thread.Sleep(300);
        return ELog.ROB_COUNTER_2.ToString();
    };

    Func<string> RobCounter3 = () => {
        Thread.Sleep(300);
        return ELog.ROB_COUNTER_3.ToString();
    };

    Func<string> LeaveBank = () => {
        Thread.Sleep(120);
        return ELog.LEAVE_BANK.ToString();
    };

    Func<string> LoosePolice = () => {
        Thread.Sleep(300);
        return ELog.LOOSE_POLICE.ToString();
    };
}