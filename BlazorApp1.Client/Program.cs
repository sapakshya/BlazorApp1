using BlazorApp1.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp1.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddAuthorizationCore();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddAuthenticationStateDeserialization();

            // HttpClient for calling server REST APIs; base address will be the origin
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
           
            // Registering services with different lifetimes to demonstrate dependency injection in Blazor WebAssembly
            // Use Transient for one-off operations or values that should not be shared.
            // Use Scoped for session-specific state and services that need to persist across multiple component usages.
            // Use Singleton for shared configuration, metadata, or services that are expensive to create.

            builder.Services.AddTransient<IGreetingService, GreetingService>();
            builder.Services.AddScoped<IUserSessionService, UserSessionService>();
            builder.Services.AddSingleton<IAppInfoService, AppInfoService>();

            await builder.Build().RunAsync();
        }
    }
}
