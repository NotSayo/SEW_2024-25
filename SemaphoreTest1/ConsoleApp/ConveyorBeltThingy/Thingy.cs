namespace ConsoleApp.ConveyorBeltThingy;

public class Thingy
{
    public string Location { get; set; }
    private readonly LinkedList<string> _locations = new LinkedList<string>();

    public Thingy()
    {
        _locations.AddLast(new LinkedListNode<string>("Unprocessed"));
        _locations.AddLast(new LinkedListNode<string>("Machine A"));
        _locations.AddLast(new LinkedListNode<string>("Machine B"));
        _locations.AddLast(new LinkedListNode<string>("Lager"));
        Location = _locations.First!.Value;
    }

    public void Move()
    {
        if (Location != "Lager")
        {
            Location = _locations.Find(Location)!.Next!.Value;
            Console.WriteLine("Moved thingy to " + Location);
        }
    }
}