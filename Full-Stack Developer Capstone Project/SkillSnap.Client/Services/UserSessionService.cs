namespace SkillSnap.Client.Services;

public class UserSessionService
{
    public string? UserId { get; set; }
    public string? Role { get; set; }

    // Optional: track currently selected or edited project
    public int? ActiveProjectId { get; set; }

    public void Clear()
    {
        UserId = null;
        Role = null;
        ActiveProjectId = null;
    }
}
