namespace Net9NewFeatures.CountBy;

public class CountByExample
{
    public static void RunTest()
    {
        Console.WriteLine("=== .NET 8 CountBy Örneği Çalıştırılıyor ===");
        CalculateCountWithNet8();

        Console.WriteLine("=== .NET 9 CountBy Örneği Çalıştırılıyor ===");
        CalculateCountWithNet9();
    }

    public static void CalculateCountWithNet8()
    {
        var products = CreateProducts();

        var productCountsByCategory = products
            .GroupBy(p => p.Category)
            .Select(group => new
            {
                Category = group.Key,
                Count = group.Count()
            });

        foreach (var category in productCountsByCategory)
        {
            Console.WriteLine($"Kategori: {category.Category}, Ürün Sayısı: {category.Count}");
        }
    }

    public static void CalculateCountWithNet9()
    {
        var products = CreateProducts();

        var productCountsByCategory = products.CountBy(p => p.Category);

        foreach (var kvp in productCountsByCategory)
        {
            Console.WriteLine($"Kategori: {kvp.Key}, Ürün Sayısı: {kvp.Value}");
        }
    }

    private static IEnumerable<Product> CreateProducts()
    {
        return
        [
            new("Elma", "Meyve"),
            new("Armut", "Meyve"),
            new("Havuç", "Sebze"),
            new("Patates", "Sebze"),
            new("Muz", "Meyve")
        ];
    }

    record Product(string Name, string Category);
}

