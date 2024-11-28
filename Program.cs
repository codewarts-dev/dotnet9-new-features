

using Net9NewFeatures.AggregateBy;
using Net9NewFeatures.CountBy;
using Net9NewFeatures.FeatureSwitch;
using Net9NewFeatures.HybridCache;
using Net9NewFeatures.Index;
using Net9NewFeatures.Lock;
using Net9NewFeatures.Params;
using Net9NewFeatures.SearchValues;
using Net9NewFeatures.SemiAutoProperties;
using Net9NewFeatures.TaskWhenEach;
using Net9NewFeatures.Uuid7;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379"; // Redis bağlantı adresi
});
// HybridCache servisinin eklenmesi. kararlı sürümde olmadığı için pragma'lar ile eklendi.  
#pragma warning disable EXTEXP0018
builder.Services.AddHybridCache();
#pragma warning restore EXTEXP0018
builder.Services.AddScoped<ProductService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); //Artık Swagger yerine Scalar kullanılabilir.
}

app.MapGet("/test-lock", () =>
{
    LockExample.RunTest();
    return new
    {
        message = "Lock testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestLock")
.WithOpenApi();

app.MapGet("/test-task-when-each", async () =>
{
    await TaskWhenEachExample.RunTest();
    return new
    {
        message = "Task.WhenEach testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestTaskWhenEach")
.WithOpenApi();

app.MapGet("/test-params", () =>
{
    ParamsExample.RunTest();
    return new
    {
        message = "Params testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestParams")
.WithOpenApi();

app.MapGet("/test-semi-auto-props", () =>
{
    SemiAutoPropertiesExample.RunTest();
    return new
    {
        message = "Semi-Auto Properties testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestSemiAutoProperties")
.WithOpenApi();

app.MapGet("/test-hybrid-cache", async (ProductService productService) =>
{
    await HybridCacheExample.RunTest(productService);
    return new
    {
        message = "HybridCache testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestHybridCache")
.WithOpenApi();

app.MapGet("/test-search-values", () =>
{
    SearchValuesExample.RunTest();
    return new
    {
        message = "SearchValues testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestSearchValues")
.WithOpenApi();

app.MapGet("/test-feature-switch", () =>
{
    FeatureSwitchExample.RunTest();
    return new
    {
        message = "FeatureSwitch testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestFeatureSwitch")
.WithOpenApi();


app.MapGet("/test-aggregateby", () =>
{
    AggregateByExample.RunTest();
    return new
    {
        message = "AggregateBy testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestAggregateBy")
.WithOpenApi();

app.MapGet("/test-countby", () =>
{
    CountByExample.RunTest();
    return new
    {
        message = "CountBy testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestCountBy")
.WithOpenApi();


app.MapGet("/test-index", () =>
{
    IndexExample.RunTest();
    return new
    {
        message = "Index testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestIndex")
.WithOpenApi();

app.MapGet("/test-uuid7", () =>
{
    Uuid7Example.RunTest();
    return new
    {
        message = "Uuid version 7 testi tamamlandı.",
        timestamp = DateTime.UtcNow
    };
})
.WithName("TestUuid7")
.WithOpenApi();


app.Run();