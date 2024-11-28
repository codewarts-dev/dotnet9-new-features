namespace Net9NewFeatures.Params;

public class ParamsExample
{
    // .NET 8'deki params kullanımı
    public static void PrintNumbersWithNet8Params(params int[] numbers) => Console.WriteLine($"NET8 int[] params : {string.Join(", ", numbers)}");
    public static void PrintWordsWithNet8Params(params string[] words) => Console.WriteLine($"NET8 string[] params : {string.Join(", ", words)}");

    //Alttaki kullanım NET8'de mümkün değil. (Compile Error : The params parameter must have a valid collection type)
    //public static void PrintNumbersWithNet8EnumerableParams(params IEnumerable<int> numbers) => Console.WriteLine($"NET8 IEnumerable<int> params : {string.Join(", ", words)}");


    // .NET 9'daki params kullanımları
    public static void PrintWordsWithNet9EnumerableParams(params ReadOnlySpan<string?> words) => Console.WriteLine($"NET9 ReadOnlySpan<string?> params : {string.Join(", ", words)}");
    public static void PrintNumbersWithNet9EnumerableParams(params IEnumerable<int> numbers) => Console.WriteLine($"NET9 IEnumerable<int> params : {string.Join(", ", numbers)}");
    public static void PrintBytesWithNet9IColletionParams(params ICollection<byte> numbers) => Console.WriteLine($"NET9 ICollection<byte> params : {string.Join(", ", numbers)}");


    public static void RunTest()
    {
        Console.WriteLine("=== .NET 8 Params Örnekleri Çalıştırılıyor ===");
        PrintNumbersWithNet8Params(1, 2, 3, 4, 5);
        PrintWordsWithNet8Params("1", "2", "3", "4", "5");

        Console.WriteLine("=== .NET 9 Params Örnekleri Çalıştırılıyor ===");
        PrintWordsWithNet9EnumerableParams("1", "2", "3", "4", "5");
        PrintNumbersWithNet9EnumerableParams(1, 2, 3, 4, 5);
        PrintBytesWithNet9IColletionParams(1, 2, 3, 4, 5);
    }
}