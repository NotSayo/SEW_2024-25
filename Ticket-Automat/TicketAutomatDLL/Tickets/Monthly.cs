namespace TicketAutomat.Tickets;

public class Monthly : ITicket
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
}