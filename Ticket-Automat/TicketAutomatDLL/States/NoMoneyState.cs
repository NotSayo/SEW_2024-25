namespace TicketAutomat.States;

public class NoMoneyState : IState
{
    public string InsertMoney(double money) => "OK: Money inserted";

    public string ChooseTicket(ETicketType ticketType) => "Error: Insert money first";

    public string PrintTicket(ETicketType ticketType) => "Error: No money to print ticket";

    public string Refund() => "Error: No money to refund";
    public string Reset() => "OK: Reset";

    public override string ToString() => this.GetType().Name.Replace("State", "");
}