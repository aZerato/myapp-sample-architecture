using MyApp.CrossCutting;
using MyApp.Domain.SampleModule.Services;
using MyApp.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.InitDatabase();
builder.Services.AddSingleton<ICacheManager, CacheManager>();
builder.Services.AddTransient<IBasicSampleService, BasicSampleService>();
builder.Services.AddTransient<ISecondaryBasicSampleService, SecondaryBasicSampleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

// APIs registration.
app.MapCacheEndpoints();
app.MapSampleEndpoints();

app.Run();
