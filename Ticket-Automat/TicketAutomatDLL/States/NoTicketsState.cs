namespace TicketAutomat.States;

public class NoTicketsState : IState
{
    public string InsertMoney(double money) => "Error: No tickets to buy";

    public string ChooseTicket(ETicketType ticketType) => "Error: No tickets to buy";

    public string PrintTicket(ETicketType ticketType) => "Error: No tickets to buy";

    public string Refund() => "OK: Money refunded";
    public string Reset() => "OK: Reset";

    public override string ToString() => this.GetType().Name.Replace("State", "");
}