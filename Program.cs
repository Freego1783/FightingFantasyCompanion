using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FightingFantasyCompanion;
using MudBlazor.Services;
using Blazored.LocalStorage;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using FightingFantasyCompanion.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAdventureService, AdventureService>();

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All));

await builder.Build().RunAsync();
