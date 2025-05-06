using System.Collections.Concurrent;
using EventEase.Models;

namespace EventEase.Services;

public class EventSessionService
{
    private readonly ConcurrentDictionary<int, List<string>> _attendance = new();

    public void RegisterUser(int eventId, object user)
    {
        var email = user.GetType().GetProperty("Email")?.GetValue(user)?.ToString();
        if (email is not null)
        {
            _attendance.AddOrUpdate(
                eventId,
                new List<string> { email },
                (key, existing) => { existing.Add(email); return existing; });
        }
    }

    public IReadOnlyList<string> GetAttendees(int eventId) =>
        _attendance.TryGetValue(eventId, out var list) ? list : new List<string>();
}
