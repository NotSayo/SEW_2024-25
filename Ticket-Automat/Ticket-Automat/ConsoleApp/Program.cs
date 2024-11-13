using TicketAutomat;

namespace ConsoleApp;

class Program
{
    public static TicketMachine _ticketMachine;
    static void Main(string[] args)
    {
        Console.WriteLine("1. Set default");
        Console.WriteLine("2. Set with amounts");
        string input = Console.ReadLine();
        if (input == "1")
            SetDefault();
        else if (input == "2")
        {
            Console.WriteLine("Enter the amounts of tickets in the following order: Hourly Daily Weekly Monthly");
            string[] amounts = Console.ReadLine().Split(" ");
            SetWithAmounts(new int[] { int.Parse(amounts[0]), int.Parse(amounts[1]), int.Parse(amounts[2]), int.Parse(amounts[3]) });
        }
        else
        {
            Console.WriteLine("Invalid input, set to default");
            SetDefault();
            return;
        }
        _ticketMachine = TicketMachine.Instance;
        ConsoleLoop().Wait();
    }

    static void SetWithAmounts(int[] amounts) => _ticketMachine = TicketMachine.SetWithAmounts(amounts);
    static void SetDefault() => _ticketMachine = TicketMachine.Instance;

    static async Task ConsoleLoop()
    {
        while (true)
        {
            PrintMenu();
            string input = Console.ReadLine();
            string result = CheckMenuInput(input);
            if (result == "Error: Invalid input")
            {
                Console.WriteLine(result);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                continue;
            }

            switch (result)
            {
                case "Insert Money":
                    Console.WriteLine("Enter the amount of money to insert");
                    double money = double.Parse(Console.ReadLine());
                    Console.WriteLine(_ticketMachine.InsertMoney(money));
                    InsertBreak();
                    break;
                case "Choose Ticket":
                    var tickets = _ticketMachine.DisplayTickets();
                    for (int i = 0; i < tickets.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tickets[i].Name} - {tickets[i].Amount } available - {tickets[i].Price} Euro");
                    }
                    int ticketType = int.Parse(Console.ReadLine());
                    if(ticketType > tickets.Count)
                    {
                        Console.WriteLine("Error: Invalid input");
                        InsertBreak();
                        continue;
                    }
                    Console.WriteLine(_ticketMachine.ChooseTicket((ETicketType)ticketType));
                    InsertBreak();
                    break;
                case "Print Ticket":
                    Console.WriteLine(await _ticketMachine.PrintTicket());
                     InsertBreak();
                    break;
                case "Refund":
                    Console.WriteLine(_ticketMachine.Refund());
                    InsertBreak();
                    break;
                case "Reset":
                    Console.WriteLine(_ticketMachine.Reset());
                    InsertBreak();
                    break;
            }
        }
    }

    static void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("------------------");
        Console.WriteLine("Ticket Master co.");
        Console.WriteLine("CurrentState: " + _ticketMachine.State.ToString());
        Console.WriteLine("Money: " + _ticketMachine.Money);
        Console.WriteLine("Options");
        Console.WriteLine("1. Insert Money");
        Console.WriteLine("2. Choose Ticket");
        Console.WriteLine("3. Print Ticket");
        Console.WriteLine("4. Refund");
        Console.WriteLine("5. Reset");
        Console.WriteLine("------------------");
    }

    static string CheckMenuInput(string inputstr)
    {
        int input;
        if(!int.TryParse(inputstr, out input))
            return "Error: Invalid input";
        switch (input)
        {
            case 1:
                return "Insert Money";
            case 2:
                return "Choose Ticket";
            case 3:
                return "Print Ticket";
            case 4:
                return "Refund";
            case 5:
                return "Reset";
        }

        return "Error: Invalid input";
    }

    static void InsertBreak()
    {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }
}