namespace ConsoleApp.TrainThingy;

public class Rail
{
    public required string Start { get; set; }
    public required string End { get; set; }
    public required SemaphoreSlim AvailableRails { get; set; }
}