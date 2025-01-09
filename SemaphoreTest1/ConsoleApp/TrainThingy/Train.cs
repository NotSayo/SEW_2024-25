namespace ConsoleApp.TrainThingy;

public class Train
{
    public required TrainController Controller { get; set; }
    public required string Name { get; set; }
    private Trainstation? CurrentLocation { get; set; }

    public void Run()
    {
        int counter = 0;
        while (true)
        {
            var rail = Controller.Rails.First(r => r is { Start: "Shizuoka", End: "Kyoto" } or
                { Start: "Kyoto", End: "Shizuoka" });
            GoToKyoto(rail);
            GoToShizuoka(rail);
            rail = Controller.Rails.First(r => r is { Start: "Shizuoka", End: "Tokyo" } or { Start: "Tokyo", End: "Shizuoka" });
            GoToTokyo(rail);
            rail = Controller.Rails.First(r => r is { Start: "Tokyo", End: "Shizuoka" } or { Start: "Shizuoka", End: "Tokyo" });
            GoToShizuoka(rail);
            counter++;

            // comment this statement if you want them to run endlessly
            if (counter >= 2)
            {
                rail = Controller.Rails.First(r => r is { Start: "Shizuoka", End: "Kyoto" } or
                    { Start: "Kyoto", End: "Shizuoka" });
                GoToKyoto(rail);
                GoBackToStorage();
                Console.WriteLine($"{Name} FINISHED!!!");
                return;
            }


        }
    }

    private void GoToKyoto(Rail rail)
    {
        if (CurrentLocation is not null)
        {
            CurrentLocation.AvailableTerminals.Release();
            rail.AvailableRails.Wait();
            Console.WriteLine($"Train {Name} is on the way to Kyoto...");
            Thread.Sleep(2000);
        }

        var location = Controller.Trainstations.First(t => t.Name == "Kyoto");
        if(CurrentLocation is not null)
            rail.AvailableRails.Release();
        location.AvailableTerminals.Wait();
        CurrentLocation = location;

        Console.WriteLine($"Train {Name} arrived in Kyoto, boarding...");
        Thread.Sleep(2000);
        Console.WriteLine($"Train {Name} completed boarding in Kyoto.");

    }

    private void GoToShizuoka(Rail rail)
    {
        CurrentLocation!.AvailableTerminals.Release();
        rail.AvailableRails.Wait();
        Console.WriteLine($"Train {Name} is on the way to Shizuoka...");
        Thread.Sleep(3000);
        CurrentLocation = Controller.Trainstations.First(t => t.Name == "Shizuoka");
        rail.AvailableRails.Release();
        CurrentLocation.AvailableTerminals.Wait();
        Console.WriteLine($"Train {Name} arrived in Shizuoka, boarding...");
        Thread.Sleep(2000);
        Console.WriteLine($"Train {Name} completed boarding in Shizuoka.");
    }

    private void GoToTokyo(Rail rail)
    {
        CurrentLocation!.AvailableTerminals.Release();
        rail.AvailableRails.Wait();
        Console.WriteLine($"Train {Name} is on the way to Tokyo...");
        Thread.Sleep(1000);
        CurrentLocation = Controller.Trainstations.First(t => t.Name == "Tokyo");
        rail.AvailableRails.Release();
        CurrentLocation.AvailableTerminals.Wait();
        Console.WriteLine($"Train {Name} arrived in Tokyo, boarding...");
        Thread.Sleep(2000);
        Console.WriteLine($"Train {Name} completed boarding in Tokyo.");
    }

    private void GoBackToStorage()
    {
        CurrentLocation!.AvailableTerminals.Release();
        CurrentLocation = null;
    }
}