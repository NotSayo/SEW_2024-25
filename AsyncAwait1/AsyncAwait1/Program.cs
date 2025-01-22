namespace AsyncAwait1;

class Program
{
    static async Task Main()
    {
        await Task.WhenAll(new[]
        {
            Task.Run(async () => await BreakfastThingy.Breakfast.Run())
        });
    }
}