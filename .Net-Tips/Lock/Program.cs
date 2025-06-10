namespace Lock;

internal class Program
{
    private static readonly object _lock = new();

    public static void Main()
    {
        //new Thread(() => ShowMessageWithLock("Thread 1")).Start();
        //new Thread(() => ShowMessageWithLock("Thread 2")).Start();
        //new Thread(() => ShowMessageWithLock("Thread 3")).Start();

        new Thread(() => ShowMessageWithMonitor("Thread 1")).Start();
        new Thread(() => ShowMessageWithMonitor("Thread 2")).Start();
        new Thread(() => ShowMessageWithMonitor("Thread 3")).Start();

        //new Thread(() => ShowMessageWithoutLock("Thread 4")).Start();
        //new Thread(() => ShowMessageWithoutLock("Thread 5")).Start();
        //new Thread(() => ShowMessageWithoutLock("Thread 6")).Start();
    }

    public static void ShowMessageWithLock(string name)
    {
        lock (_lock)
        {
            Console.WriteLine($"{name} - enter lock");
            Thread.Sleep(1000);
            Console.WriteLine($"{name} - exit lock");
        }
    }

    public static void ShowMessageWithMonitor(string name)
    {
        bool lockTaken = false;
        try
        {
            Monitor.Enter(_lock, ref lockTaken);

            Console.WriteLine($"{name} - enter lock");
            Thread.Sleep(1000);
            Console.WriteLine($"{name} - exit lock");
        }
        finally
        {
            if (lockTaken)
            {
                Monitor.Exit(_lock);
            }
        }
    }

    public static void ShowMessageWithoutLock(string name)
    {
        Console.WriteLine($"{name} - enter");
        Thread.Sleep(1000);
        Console.WriteLine($"{name} - exit");
    }
}
