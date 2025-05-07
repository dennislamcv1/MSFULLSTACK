/// <summary>
/// Creates a new instance of the <see cref="WebApplicationBuilder"/> class
/// using the specified command-line arguments.
/// </summary>
/// <param name="args">An array of command-line arguments passed to the application.</param>

using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);


// Register in-memory caching
builder.Services.AddMemoryCache();

var app = builder.Build();

var cache = app.Services.GetRequiredService<IMemoryCache>();

app.MapGet("/api/productlist", (IMemoryCache memoryCache) =>
{
    const string cacheKey = "product_list";

    if (!memoryCache.TryGetValue(cacheKey, out object? cachedProducts))
    {
        var products = new[]
        {
            new
            {
                Id = 1,
                Name = "Laptop",
                Price = 1200.50,
                Stock = 25,
                Category = new { Id = 101, Name = "Electronics" }
            },
            new
            {
                Id = 2,
                Name = "Headphones",
                Price = 50.00,
                Stock = 100,
                Category = new { Id = 102, Name = "Accessories" }
            }
        };

        var cacheOptions = new MemoryCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(5)
        };

        memoryCache.Set(cacheKey, products, cacheOptions);

        cachedProducts = products;
    }

    return Results.Ok(cachedProducts);
});

app.Run();