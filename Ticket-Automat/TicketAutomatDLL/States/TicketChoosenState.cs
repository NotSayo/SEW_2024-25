namespace TicketAutomat.States;

public class TicketChoosenState : IState
{
    public string InsertMoney(double money) => "OK: Money inserted";

    public string ChooseTicket(ETicketType ticketType) => "OK: Ticket changed";

    public string PrintTicket(ETicketType ticketType) => "OK: Ticket printed";

    public string Refund() => "OK: Money refunded";
    public string Reset() => "OK: Reset, money refunded";

    public override string ToString() => this.GetType().Name.Replace("State", "");
}