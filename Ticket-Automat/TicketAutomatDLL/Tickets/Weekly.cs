namespace TicketAutomat.Tickets;

public class Weekly : ITicket
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
}