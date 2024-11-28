namespace Net9NewFeatures.Lock;

using System.Threading;

public class LockExample
{
    public static void RunTest()
    {
        Console.WriteLine("=== .NET 8 Lock Örneği Çalıştırılıyor ===");
        var lockWithDotNet8 = new CounterNet8();
        var net8CounterIncrementTasks = new List<Task>();
        Parallel.For(0, 4, i =>
        {
            var task = Task.Run(() => lockWithDotNet8.Increment(i));
            net8CounterIncrementTasks.Add(task);
        });
        Task.WaitAll([.. net8CounterIncrementTasks]);

        Console.WriteLine("=== .NET 9 Lock Örneği Çalıştırılıyor ===");
        var lockWithDotNet9 = new CounterNet9();
        var net9CounterIncrementTasks = new List<Task>();
        Parallel.For(0, 4, i =>
        {
            var task = Task.Run(() => lockWithDotNet9.Increment(i));
            net9CounterIncrementTasks.Add(task);
        });
        Task.WaitAll([.. net9CounterIncrementTasks]);
    }
}

public class CounterNet8
{
    private readonly object _lock = new();
    private int _count;

    public void Increment(int taskId)
    {
        Console.WriteLine($"#{taskId} için lock öncesi _count = {_count}.");
        lock (_lock)
        {
            Console.WriteLine($"#{taskId} için lock içinde _count = {_count}.");
            _count++;
        }
        Console.WriteLine($"#{taskId} için lock sonrası _count = {_count}.");
    }
}



public class CounterNet9
{
    private readonly Lock _lock = new();
    private int _count;

    public void Increment(int taskId)
    {
        Console.WriteLine($"#{taskId} için lock öncesi _count = {_count}.");
        lock (_lock)
        {
            Console.WriteLine($"#{taskId} için lock içinde _count = {_count}.");
            _count++;
        }
        Console.WriteLine($"#{taskId} için lock sonrası _count = {_count}.");
    }
}
