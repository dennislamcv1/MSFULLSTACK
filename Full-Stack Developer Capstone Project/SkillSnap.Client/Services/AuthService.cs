using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using SkillSnap.Client.Models;

namespace SkillSnap.Client.Services;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var response = await _http.PostAsJsonAsync("api/auth/login", new { email, password });
        if (!response.IsSuccessStatusCode) return false;

        var json = await response.Content.ReadAsStringAsync();
        var tokenObj = JsonSerializer.Deserialize<JwtResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (tokenObj is not null)
        {
            await _localStorage.SetItemAsync("authToken", tokenObj.Token);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenObj.Token);
            return true;
        }

        return false;
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync("authToken");
        _http.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<string?> GetTokenAsync() =>
        await _localStorage.GetItemAsync<string>("authToken");

    private class JwtResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}
