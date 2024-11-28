namespace Net9NewFeatures.TaskWhenEach;

public class TaskWhenEachExample
{
    public static async Task RunTest()
    {
        Console.WriteLine("=== .NET 8 WhenAll Örneği Çalıştırılıyor ===");
        await DotNet8Example();

        Console.WriteLine("=== .NET 9 Task.WhenEach Örneği Çalıştırılıyor ===");
        await DotNet9Example();
    }

    // .NET 8'deki yaklaşım
    public static async Task DotNet8Example()
    {
        var tasks = CreateTasks();

        await Task.WhenAll(tasks);

        foreach (var task in tasks)
        {
            Console.WriteLine($"{await task}");
        }
    }

    // .NET 9'daki yeni yaklaşım
    public static async Task DotNet9Example()
    {
        var tasks = CreateTasks();

        await foreach (var task in Task.WhenEach(tasks))
        {
            Console.WriteLine($"{await task}");
        }
    }

    private static List<Task<string>> CreateTasks()
    {
        return
        [
            SimulateApiCallAsync("API 1"),
            SimulateApiCallAsync("API 2"),
            SimulateApiCallAsync("API 3")
        ];
    }

    private static async Task<string> SimulateApiCallAsync(string name)
    {
        await Task.Delay(1000);
        return $"{name} işlemi tamamlandı.";
    }
}