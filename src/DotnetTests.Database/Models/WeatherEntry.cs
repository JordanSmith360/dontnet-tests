namespace DotnetTests.Database.Models;

public class WeatherEntry
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal TemperatureCelsius { get; set; }
    public string Summary { get; set; } = string.Empty;
}
