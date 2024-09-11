using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using SessionManagerExample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services
    .AddFeatureManagement()
    .AddFeatureFilter<PercentageFilter>()
    .AddSessionManager<SessionManager>();

var app = builder.Build();

app.MapGet("/check", ([FromServices] IFeatureManager featureManager) =>
{
    return featureManager.IsEnabledAsync(FeatureFlags.SomeFeature);
});

app.Run();