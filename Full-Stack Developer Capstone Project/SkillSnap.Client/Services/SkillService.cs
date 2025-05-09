using System.Net.Http.Json;
using SkillSnap.Client.Models;

namespace SkillSnap.Client.Services;

public class SkillService
{
    private readonly HttpClient _http;

    public SkillService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Skill>> GetSkillsAsync()
    {
        var skills = await _http.GetFromJsonAsync<List<Skill>>("api/skills");
        return skills ?? new List<Skill>();
    }

    public async Task AddSkillAsync(Skill newSkill)
    {
        var response = await _http.PostAsJsonAsync("api/skills", newSkill);
        response.EnsureSuccessStatusCode();
    }
}
