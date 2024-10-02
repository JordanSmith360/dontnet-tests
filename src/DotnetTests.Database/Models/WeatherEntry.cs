namespace DotnetTests.Database.Models;

public class WeatherEntry : BaseEntity
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal TemperatureCelsius { get; set; }
    public string Summary { get; set; } = string.Empty;
}
