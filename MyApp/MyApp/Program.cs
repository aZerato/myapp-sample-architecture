using Microsoft.AspNetCore.Http.HttpResults;
using MyApp.CrossCutting;
using MyApp.Domain.SampleModule.Services;
using MyApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.InitDatabase();
builder.Services.AddSingleton<ICacheManager, CacheManager>();
builder.Services.AddTransient<IBasicSampleService, BasicSampleService>();
builder.Services.AddTransient<ISecondaryBasicSampleService, SecondaryBasicSampleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/cache",
    (
        ICacheManager cacheManager
    ) =>
    {
        var results = cacheManager.GetAll();

        return Results.Ok(results);
    });

app.MapGet("/cache/{key}",
    (
        string key,
        ICacheManager cacheManager
    ) =>
    {
        var result = cacheManager.Get(key);

        return Results.Ok(result);
    });

app.MapPost("/cache", 
    Results<BadRequest, Ok> (
        CacheRequest cacheRequest,
        ICacheManager cacheManager
    ) =>
{
    if (cacheRequest == null || 
    string.IsNullOrEmpty(cacheRequest.Key))
    {
        return TypedResults.BadRequest();
    }

    if (cacheManager.Get(cacheRequest.Key) != null)
    {
        return TypedResults.BadRequest();
    }

    if (string.IsNullOrEmpty(cacheRequest.Value))
    {
        return TypedResults.BadRequest();
    }

    cacheManager.Add(cacheRequest.Key, cacheRequest.Value);
    
    return TypedResults.Ok();
});

app.Run();
