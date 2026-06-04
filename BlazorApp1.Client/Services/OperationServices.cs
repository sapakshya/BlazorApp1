using System;

namespace BlazorApp1.Client.Services
{
    /// <summary>
    /// Transient service example: a new instance is created each time it is requested.
    /// This service generates a greeting and a unique instance identifier.
    /// </summary>
    public interface IGreetingService
    {
        Guid InstanceId { get; }
        string Greeting { get; }
    }

    /// <summary>
    /// Scoped service example: same instance is reused within the same Blazor WebAssembly scope.
    /// This service tracks session-specific page views for the current browser session.
    /// </summary>
    public interface IUserSessionService
    {
        Guid SessionId { get; }
        string UserName { get; }
        int PageViewCount { get; }
        void IncrementPageView();
    }

    /// <summary>
    /// Singleton service example: 
    /// one instance is created once and stays alive for the app lifetime.
    /// This service stores application metadata shared across all components.
    /// </summary>
    public interface IAppInfoService
    {
        Guid InstanceId { get; }
        string AppName { get; }
        DateTimeOffset StartedAt { get; }
    }

    public class GreetingService : IGreetingService
    {
        public GreetingService()
        {
            InstanceId = Guid.NewGuid();
            Greeting = $"Welcome! This transient greeting was created at {DateTimeOffset.UtcNow:HH:mm:ss} UTC.";
        }

        public Guid InstanceId { get; }
        public string Greeting { get; }
    }

    public class UserSessionService : IUserSessionService
    {
        public UserSessionService()
        {
            SessionId = Guid.NewGuid();
            UserName = "Guest user";
            PageViewCount = 0;
        }

        public Guid SessionId { get; }
        public string UserName { get; }
        public int PageViewCount { get; private set; }

        public void IncrementPageView()
        {
            PageViewCount++;
        }
    }

    public class AppInfoService : IAppInfoService
    {
        public AppInfoService()
        {
            InstanceId = Guid.NewGuid();
            AppName = "BlazorApp1 Lifetime Demo";
            StartedAt = DateTimeOffset.UtcNow;
        }

        public Guid InstanceId { get; }
        public string AppName { get; }
        public DateTimeOffset StartedAt { get; }
    }
}
