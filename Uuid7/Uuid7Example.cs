namespace Net9NewFeatures.Uuid7;

public class Uuid7Example
{
    public static void RunTest()
    {
        Console.WriteLine("=== .NET 8 Uuid4 (Guid.NewGuid) Örneği Çalıştırılıyor ===");
        List<Guid> userIdv4List = Enumerable.Range(1, 10)
                                    .Select(i => Guid.NewGuid())
                                    .ToList();

        foreach (var id in userIdv4List)
        {
            Console.WriteLine(id);
        }

        Console.WriteLine("=== .NET 9 Uuid7 (Guid.CreateVersion7) Örneği Çalıştırılıyor ===");

        List<Guid> userIdv7List = Enumerable.Range(1, 10)
                            .Select(i => Guid.CreateVersion7())
                            .ToList();

        foreach (var id in userIdv7List)
        {
            Console.WriteLine(id);
        }
    }
}