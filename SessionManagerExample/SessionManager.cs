using Microsoft.FeatureManagement;

namespace SessionManagerExample;

public class SessionManager(IHttpContextAccessor httpContextAccessor) : ISessionManager
{
    public Task SetAsync(string featureName, bool enabled)
    {
        if (featureName is not FeatureFlags.SomeFeature)
            return Task.CompletedTask;

        var httpContext = httpContextAccessor.HttpContext;

        if (httpContext is null)
            throw new InvalidOperationException();
        
        httpContext.Response.Cookies.Append($"feature_{featureName.ToLower()}", enabled.ToString());
        
        return Task.CompletedTask;
    }

    public Task<bool?> GetAsync(string featureName)
    {
        var httpContext = httpContextAccessor.HttpContext;

        if (httpContext is null)
            throw new InvalidOperationException();

        if (!httpContext.Request.Cookies.TryGetValue($"feature_{featureName.ToLower()}", out var enabledString))
            return Task.FromResult<bool?>(null);

        var result = bool.TryParse(enabledString, out var enabled) ? enabled : null as bool?;

        return Task.FromResult(result);
    }
}