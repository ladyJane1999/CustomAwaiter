using CustomAwaiter;

public class Program
{
    static async Task Main(string[] args)
    {
        MyObject me = new MyObject();
      
        Console.WriteLine($"Run {Thread.CurrentThread.ManagedThreadId}");
        _ = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine($"SetCompleted {Thread.CurrentThread.ManagedThreadId}");
            me.SetCompleted();
        });
        await me;
        Console.WriteLine($"After await {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(2000);
    }
}