  using DonutsGo.WebUI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7068/") });

//builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
//builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
 