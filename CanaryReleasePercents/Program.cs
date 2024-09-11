using CanaryReleasePercents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFeatureManagement()
    .AddFeatureFilter<PercentageFilter>();

var app = builder.Build();

app.MapGet("/check", async ([FromServices] IFeatureManager featureManager) =>
{
    return await featureManager.IsEnabledAsync(FeatureFlags.SomeFeature);
});

app.Run();