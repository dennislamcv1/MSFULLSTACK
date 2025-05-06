namespace EventEase.Models;

public class Event
{
    public int Id { get; set; }  // Needed for routing
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Location { get; set; } = string.Empty;
}
