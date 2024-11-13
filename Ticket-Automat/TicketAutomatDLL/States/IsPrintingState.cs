namespace TicketAutomat.States;

public class IsPrintingState : IState
{
    public string InsertMoney(double money) => "Error: Ticket is printing";

    public string ChooseTicket(ETicketType ticketType) => "Error: Ticket is printing";

    public string PrintTicket(ETicketType ticketType) => "Error: Ticket is printing";

    public string Refund() => "Error: Ticket is printing";
    public string Reset() => "Error: Wait for the machine to stop printing";

    public override string ToString() => this.GetType().Name.Replace("State", "");
}