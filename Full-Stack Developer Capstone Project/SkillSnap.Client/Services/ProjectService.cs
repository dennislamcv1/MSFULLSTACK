using System.Net.Http.Json;
using SkillSnap.Client.Models; // Create this if needed

namespace SkillSnap.Client.Services;

public class ProjectService
{
    private readonly HttpClient _http;

    public ProjectService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Project>> GetProjectsAsync()
    {
        var projects = await _http.GetFromJsonAsync<List<Project>>("api/projects");
        return projects ?? new List<Project>();
    }

    public async Task AddProjectAsync(Project newProject)
    {
        var response = await _http.PostAsJsonAsync("api/projects", newProject);
        response.EnsureSuccessStatusCode();
    }
}
