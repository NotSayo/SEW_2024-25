using ConsoleApp.CollectorThingy;
using ConsoleApp.CraneMachineThingy;
using ConsoleApp.HarborThingy;
using ConsoleApp.KebabThingy;
using ConsoleApp.Race;

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


}