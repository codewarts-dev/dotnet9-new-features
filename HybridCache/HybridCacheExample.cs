namespace Net9NewFeatures.HybridCache;

using Microsoft.Extensions.Caching.Hybrid;

public class HybridCacheExample
{
    public static async Task RunTest(ProductService productService)
    {
        Console.WriteLine("=== .NET 9 HybridCache Örneği Çalıştırılıyor ===");

        for (int i = 0; i < 3; i++)
        {
            await productService.GetProductByIdAsync(1);
        }

        //Cachelenmiş datanın silinmesi için 2 sn gecikme (HybridCacheEntryOptions.LocalCacheExpiration)
        await Task.Delay(TimeSpan.FromSeconds(2));

        for (int i = 0; i < 3; i++)
        {
            await productService.GetProductByIdAsync(1);
        }
    }
}

public class ProductService(HybridCache hybridCache)
{
    public async Task GetProductByIdAsync(int id)
    {
        var cachedProductId = await hybridCache.GetOrCreateAsync(
            key: id.ToString(),
            factory: async cancelToken => await FetchProductFromDatabaseAsync(id),
            options: new HybridCacheEntryOptions()
            {
                LocalCacheExpiration = TimeSpan.FromSeconds(2),
                Flags = HybridCacheEntryFlags.DisableDistributedCache //Distributed Cache kullanma!
            },
            cancellationToken: CancellationToken.None
        );

        Console.WriteLine($"#{cachedProductId} numaralı ürün HybridCache'den getirildi.");
    }

    private static async Task<int> FetchProductFromDatabaseAsync(int id)
    {
        // Simüle edilmiş veritabanı sorgusu
        await Task.Delay(100); // Simülasyon amaçlı gecikme
        Console.WriteLine($"#{id} numaralı ürün veritabanından getirildi...");
        return id;
    }
}

public record Product(int Id, string Name, decimal Price);
