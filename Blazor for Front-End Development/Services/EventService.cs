using EventEase.Models;

public class EventService
{
    private List<Event> events = new()
    {
        new Event { Id = 1, Name = "Tech Conference 2025", Date = new DateTime(2025, 6, 12), Location = "New York" },
        new Event { Id = 2, Name = "Business Summit", Date = new DateTime(2025, 7, 20), Location = "San Francisco" }
    };

    public List<Event> GetEvents() => events;

    public Event? GetEventById(int id) => events.FirstOrDefault(e => e.Id == id);
}
