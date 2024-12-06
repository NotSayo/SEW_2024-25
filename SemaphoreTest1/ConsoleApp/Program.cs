using ConsoleApp.CollectorThingy;
using ConsoleApp.CraneMachineThingy;
using ConsoleApp.KebabThingy;

namespace ConsoleApp;

class Program
{

    static void Main(string[] args)
    {
        // Semaphore_In_Out.TestSemaphore(10);
        //StartCollector();
        //StartCraneMachine();
        StartKebab();
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


}