using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TaxCalculator.Web;
using TaxCalculator.Web.Services;
using TaxCalculator.Web.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7289/") });

builder.Services.AddScoped<ITaxCalculatorService, TaxCalculatorService>();

await builder.Build().RunAsync();
