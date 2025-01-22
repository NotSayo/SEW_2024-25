using System.Diagnostics;

namespace AsyncAwait1.BreakfastThingy;

public static class Breakfast
{
    public static async Task Run()
    {
        var watch = new Stopwatch();
        watch.Start();
        await PourCoffee();
        Console.WriteLine("Coffee done");
        await Task.WhenAll(new []
        {
            Task.Run(async() => {await FryEggs(); Console.WriteLine("Eggs done");}),
            Task.Run(async() => {await FryBacon(); Console.WriteLine("Bacon done");}),
            Task.Run(async() => {await ToastBread(); Console.WriteLine("Toast done");})
        });
        await PourJuice();
        Console.WriteLine("Juice done");

        Console.WriteLine("Done");


        watch.Stop();
        Console.WriteLine($"Breakfast is ready in {watch.ElapsedMilliseconds} ms.");
    }





    public static async Task PourCoffee()
    {
        await Task.Delay(2000);

    }

    public static async Task FryEggs()
    {
        await Task.Delay(3000);
    }

    public static async Task FryBacon()
    {
        await Task.Delay(3000);
    }

    public static async Task ToastBread()
    {
        await Task.Delay(3000);
        await Task.Delay(3000);
    }

    public static async Task PourJuice()
    {
        await Task.Delay(2000);
    }
}