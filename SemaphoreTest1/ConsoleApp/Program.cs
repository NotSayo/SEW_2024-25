using ConsoleApp.CollectorThingy;
using ConsoleApp.ConveyorBeltThingy;
using ConsoleApp.CraneMachineThingy;
using ConsoleApp.HarborThingy;
using ConsoleApp.KebabThingy;
using ConsoleApp.RaceThingy;
using ConsoleApp.TrainThingy;

namespace ConsoleApp;

class Program
{

    static void Main(string[] args)
    {

        // Semaphore_In_Out.TestSemaphore(10);
        //StartCollector();
        //StartCraneMachine();
        // StartKebab();
        // StartRace();
        StartHarbor();
        //StartBelt();
        //StartTrains();
    }
    static void StartCollector()
    {
        CollectorManager manager = new CollectorManager();
        while(true) {}
    }

    static void StartCraneMachine()
    {
        new Thread(new Crane() {Code = "Crane"}.Run).Start();
    }

    static void StartKebab()
    {
        new Thread(new KebabShop().Run).Start();
    }

    static void StartRace()
    {
        new Thread(new RaceController().Run).Start();
    }

    static void ParameterThread(string s)
    {
        Console.WriteLine(s);
    }

    static void StartHarbor()
    {
        new Thread(new Harbor().Run).Start();
    }

    static void StartBelt()
    {
        new Thread(new Belt().Run).Start();
    }

    static void StartTrains()
    {
        new Thread(new TrainController(100).Run).Start();
    }
}