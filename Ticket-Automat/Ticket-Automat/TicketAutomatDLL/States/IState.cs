namespace TicketAutomat.States;

public interface IState
{
    public string InsertMoney(double money);
    public string ChooseTicket(ETicketType ticketType);
    public string PrintTicket(ETicketType ticketType);
    public string Refund();

    public string Reset();
    
}