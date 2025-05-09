using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SkillSnap.Client;
using Blazored.LocalStorage;


//using SkillSnap.Client.Services;

//builder.Services.AddScoped<AuthService>();


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazoredLocalStorage();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<SkillSnap.Client.Services.ProjectService>();
builder.Services.AddScoped<SkillSnap.Client.Services.SkillService>();

builder.Services.AddScoped<SkillSnap.Client.Services.UserSessionService>();


// builder.Services.AddScoped(sp =>
// {
//     var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
//     var localStorage = sp.GetRequiredService<ILocalStorageService>();
//     var authService = sp.GetRequiredService<AuthService>();

//     localStorage.GetItemAsync<string>("authToken").ContinueWith(task =>
//     {
//         var token = task.Result;
//         if (!string.IsNullOrWhiteSpace(token))
//         {
//             http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
//         }
//     });

//     return http;
// });



await builder.Build().RunAsync();
