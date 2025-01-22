


for (var i = 0; i < 100; i++)
{
    int local = i;
    MyThreadPool.QueueUserWorkItem(() =>
    {
        Console.WriteLine(local);
    });
}

Console.ReadKey();

static class MyThreadPool
{
    public static List<Thread> RunnerThreads { get; set; } = new List<Thread>();
    private static Queue<Action> Threads { get; set; } = new Queue<Action>();
    public static void QueueUserWorkItem(Action action)
    {
        Threads.Enqueue(action);
    }

    static MyThreadPool()
    {
        for (int i = 0; i < 3; i++)
            RunnerThreads.Add(new Thread(ThreadRunner));
        RunnerThreads.ForEach(s => s.Start());
    }

    private static void ThreadRunner()
    {
        while (true)
        {
            if(Threads.Any())
                Threads.Dequeue().Invoke();
        }
    }

}