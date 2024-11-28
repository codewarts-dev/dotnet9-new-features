namespace Net9NewFeatures.SearchValues;

using System.Buffers;

public class SearchValuesExample
{
    public static void RunTest()
    {
        var text = "NET 8 ve NET 9'da search values kullanımı!".AsSpan();

        Console.WriteLine("=== .NET 8 Search Values Örneği Çalıştırılıyor ===");
        var numberSearch = SearchValues.Create(['8', '9']);
        Console.WriteLine($".NET 8 ContainsAny(char[] SearchValues) : {text.ContainsAny(numberSearch)}");

        Console.WriteLine("=== .NET 9 Search Values Örneği Çalıştırılıyor ===");
        var keywordSearch = SearchValues.Create([".net", "search", "values"], StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($".NET 9 ContainsAny(string[] SearchValues) : {text.ContainsAny(keywordSearch)}");
    }
}