using ConsoleApp.CollectorThingy;
using ConsoleApp.CraneMachineThingy;

namespace ConsoleApp;

class Program
{

    static void Main(string[] args)
    {
        // Semaphore_In_Out.TestSemaphore(10);
        //StartCollector();
        StartCraneMachine();
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


}