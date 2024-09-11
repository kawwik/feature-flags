using CanaryRelease;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFeatureManagement()
    .AddFeatureFilter<InnFeatureFilter>();

var app = builder.Build();

app.MapGet("/check", async ([FromQuery(Name = "inn")] string inn,[FromServices] IFeatureManager featureManager) =>
{
    return await featureManager.IsEnabledAsync(FeatureFlags.SomeFeature, new InnContext(inn));
});

app.Run();