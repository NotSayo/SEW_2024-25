namespace TicketAutomat.States;

public class HasMoneyState : IState
{
    public string InsertMoney(double money) => "OK: Money inserted";

    public string ChooseTicket(ETicketType ticketType) => "OK: Ticket chosen";

    public string PrintTicket(ETicketType ticketType) => "Error: Choose ticket first";

    public string Refund() => "OK: Money refunded";
    public string Reset() => "OK: Reset, money refunded";

    public override string ToString() => this.GetType().Name.Replace("State", "");
}