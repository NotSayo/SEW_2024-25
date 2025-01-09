namespace ConsoleApp.TrainThingy;

public class Trainstation
{
    public required string Name { get; set; }
    public int Terminals { get; set; }
    public SemaphoreSlim AvailableTerminals { get; private set; }

    public Trainstation(int terminals)
    {
        Terminals = terminals;
        AvailableTerminals = new SemaphoreSlim(terminals, maxCount: terminals);
    }

}