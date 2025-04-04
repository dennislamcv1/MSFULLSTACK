using EventEase.Services;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton<EventService>(); // Register EventService
await builder.Build().RunAsync();





public class Event
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Location { get; set; } = string.Empty;
}
