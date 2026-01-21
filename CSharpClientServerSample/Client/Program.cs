
using System.Net.Http.Json;

Console.WriteLine("Client starting... Waiting 2 seconds for server...");
await Task.Delay(2000);

using var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5000"); // Default Kestrel HTTP port

try
{
    var forecasts = await client.GetFromJsonAsync<List<WeatherForecastVM>>("/weatherforecast");
    if (forecasts is null)
    {
        Console.WriteLine("No data returned.");
        return;
    }
    Console.WriteLine("Received weather forecast from server:");
    foreach (var f in forecasts)
    {
        Console.WriteLine($"{f.Date:yyyy-MM-dd} | {f.TemperatureC,3}C | {f.TemperatureF,3}F | {f.Summary}");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error calling server: " + ex.Message);
    Console.WriteLine("Make sure the Server project is running on http://localhost:5000");
}

public class WeatherForecastVM
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF { get; set; }
    public string? Summary { get; set; }
    public bool? Enabled { get; set; }
}

In the Program class, add a new parameter named Input of type string to the WeatherForecastVM class.
In the WeatherForecastVM class, add a new public property named Input of type string immediately after the Enabled property.
# Change applied: Add a new public property named VALUE of type string in the Program.cs file, immediately after the existing Enabled property.
