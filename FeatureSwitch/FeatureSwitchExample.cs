namespace Net9NewFeatures.FeatureSwitch;

using System.Diagnostics.CodeAnalysis;

public class FeatureSwitchExample
{
    public static void RunTest()
    {
        Console.WriteLine("=== .NET 9 FeatureSwitch Örneği Çalıştırılıyor ===");

        if (FeatureY.IsEnabled)
            FeatureY.ExecuteFeature(); // Yalnızca etkinse çalışacak
        else
            Console.WriteLine("Feature Y çalışmıyor! .csproj dosyasını ve FeatureY.IsEnabled FeatureSwitch değerini güncelleyin.");
    }
}

public static class FeatureY
{
    [FeatureSwitchDefinition("FeatureY.IsEnabled")]
    public static bool IsEnabled => AppContext.TryGetSwitch("FeatureY.IsEnabled", out bool isEnabled) && isEnabled;

    public static void ExecuteFeature()
    {
        Console.WriteLine("Feature Y çalışıyor!");
    }
}