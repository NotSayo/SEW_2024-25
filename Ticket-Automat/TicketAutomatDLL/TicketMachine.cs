using System.Runtime;
using TicketAutomat.States;
using TicketAutomat.Tickets;

namespace TicketAutomat;

public class TicketMachine
{
    /// <summary>
    ///     Returns the instance of the TicketMachine. If the instance was not set, it will create a new one.
    ///     If the instance is set once, SetWithAmounts cannot be used.
    /// </summary>
    public static TicketMachine Instance => instance ??= new TicketMachine();
    /// <summary>
    /// Method for creating the instance of the TicketMachine with the given amounts.
    /// </summary>
    /// <param name="amounts">The array should include 4 items.</param>
    /// <returns>The instance. Same as Instance</returns>
    /// <exception cref="AlreadyExistsException">The instance was already set and cannot be set again.</exception>
    /// <exception cref="ArgumentException">The amount of parameters was wrong. It should be 4.</exception>
    public static TicketMachine SetWithAmounts(int[] amounts)
    {
        if (instance is not null) throw new AlreadyExistsException();
       if(amounts.Length != 4) throw new ArgumentException();
        instance = new TicketMachine(amounts);
        return instance;
    }
    private static TicketMachine? instance;

    private TicketMachine(int[]? amounts = null)
    {
        amounts ??= new int[] { 10,10,10,10 };
        Money = 0;
        Tickets = new List<ITicket>()
        {
            new Hourly() {Name = "Hourly", Price = 5, Amount = amounts[0]},
            new Daily() {Name = "Daily", Price = 5, Amount = amounts[1]},
            new Weekly() {Name = "Weekly", Price = 20, Amount = amounts[2]},
            new Monthly() {Name = "Monthly", Price = 50, Amount = amounts[3]}
        };
        UpdateState();
    }

    #region Methods

    public string InsertMoney(double money)
    {
        var result = State.InsertMoney(money);
        if (result.StartsWith("OK"))
        {
            Money += money;
            UpdateState();
        }
        return result;
    }

    public string ChooseTicket(ETicketType ticketType)
    {
        if (Tickets.Where(s => s.Name == ticketType.ToString()).First().Amount == 0)
            return "Error: No tickets available";
        var result = State.ChooseTicket(ticketType);
        if (result.StartsWith("OK"))
        {
            ChosenTicket = ticketType;
            UpdateState();
        }
        return result;
    }

    public List<ITicket> DisplayTickets()
    {
        return Tickets;
    }

    public async Task<string> PrintTicket()
    {
        var result = State.PrintTicket(ChosenTicket);
        if (result.StartsWith("OK"))
        {
            if(Money < Tickets.Where(s => s.Name == ChosenTicket.ToString()).First().Price)
                return "Error: Not enough money";
            Tickets.Where(s => s.Name == ChosenTicket.ToString()).First().Amount--;
            isPrinting = true;
            UpdateState();
            await Task.Delay(2000);
            isPrinting = false;
            Money -= Tickets.Where(s => s.Name == ChosenTicket.ToString()).First().Price;
            ChosenTicket = ETicketType.None;
            UpdateState();
        }
        return result;
    }

    public string Refund()
    {
        var result = State.Refund();
        if (result.StartsWith("OK"))
        {
            Money = 0;
            UpdateState();
        }
        return result;
    }

    #endregion

    public IState State { get; private set; }
    public double Money { get; private set; }
    private List<ITicket> Tickets = new List<ITicket>();

    private ETicketType ChosenTicket { get;  set; } = ETicketType.None;
    private bool isPrinting { get;  set; } = false;

    private void UpdateState()
    {
        if (!Tickets.Any(s => s.Amount > 0))
        {
            State = new NoTicketsState();
            return;
        }

        if (Money == 0)
        {
            State = new NoMoneyState();
            return;
        }

        if (isPrinting)
        {
            State = new IsPrintingState();
            return;
        }

        if(ChosenTicket != ETicketType.None)
        {
            State = new TicketChoosenState();
            return;
        }

        State = new HasMoneyState();
    }

    public string Reset()
    {
        var result = State.Reset();
        if (result.StartsWith("Error:"))
            return result;
        Money = 0;
        ChosenTicket = ETicketType.None;
        isPrinting = false;
        UpdateState();
        return State.Reset();
    }

}