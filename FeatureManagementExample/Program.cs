using FeatureManagementExample;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFeatureManagement();

var app = builder.Build();

app.MapGet("/check", async ([FromServices] IFeatureManager featureManager) =>
{
    return await featureManager.IsEnabledAsync(FeatureFlags.SomeFeature);
});

app.Run();