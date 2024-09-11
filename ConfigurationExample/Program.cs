using Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<ExampleClassSettings>(builder.Configuration.GetSection(nameof(ExampleClassSettings)));

var app = builder.Build();

app.MapGet("/check", ([FromServices] IServiceProvider serviceProvider) =>
{
    var settings = serviceProvider.GetRequiredService<IOptionsMonitor<ExampleClassSettings>>();

    return settings.CurrentValue.SomeFeature;
});

app.Run();