using Blazorise;
using Blazorise.FluentValidation;
using Blazorise.Icons.Material;
using Blazorise.Material;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UniqueHabits.Contracts.Validators;
using UniqueHabits.Shared;
using UnqiueHabits.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<HabitState>();
builder.Services.AddSingleton<HabitService>();

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
