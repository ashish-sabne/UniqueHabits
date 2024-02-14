using Blazorise;
using Blazorise.FluentValidation;
using Blazorise.Icons.Material;
using Blazorise.Material;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UniqueHabits.Contracts.Services;
using UniqueHabits.Contracts.Validators;
using UnqiueHabits.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<HabitState>();
builder.Services.AddScoped<HabitService>();

builder.Services.AddHttpClient<HabitService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7135/");
});

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddMaterialProviders()
    .AddMaterialIcons()
    .AddBlazoriseFluentValidation()
    .AddValidatorsFromAssembly(typeof(HabitValidator).Assembly);

await builder.Build().RunAsync();
