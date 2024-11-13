namespace TicketAutomat.Tickets;

public interface ITicket
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
}