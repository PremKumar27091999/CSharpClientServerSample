
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/weatherforecast", () =>
{
    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    var startDate = DateOnly.FromDateTime(DateTime.Now);
    var rng = new Random();
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    (
        Date: startDate.AddDays(index),
        TemperatureC: rng.Next(-20, 55),
        Summary: summaries[rng.Next(summaries.Length)]
    ));
})
.WithName("GetWeatherForecast")
.Produces<IEnumerable<WeatherForecast>>(StatusCodes.Status200OK);

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
