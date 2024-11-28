namespace Net9NewFeatures.Index;

public class IndexExample
{
    public static void RunTest()
    {
        Console.WriteLine("=== .NET 8 Index Örneği Çalıştırılıyor ===");
        CalculateIndexWithNet8();

        Console.WriteLine("=== .NET 9 Index Örneği Çalıştırılıyor ===");
        CalculateIndexWithNet9();
    }

    private static void CalculateIndexWithNet9()
    {
        var members = CreateMembers();

        foreach (var (index, member) in members.Index())
        {
            Console.WriteLine($"Üye {index}: {member}");
        }
    }

    private static void CalculateIndexWithNet8()
    {
        var members = CreateMembers();

        foreach (var (index, member) in members.Select((mmbr, indexOfMember) => (indexOfMember, mmbr)))
        {
            Console.WriteLine($"Üye {index}: {member}");
        }
    }

    private static string[] CreateMembers()
    {
        return ["Ahmet", "Mehmet", "Ayşe", "Fatma", "Hasan"];
    }
}