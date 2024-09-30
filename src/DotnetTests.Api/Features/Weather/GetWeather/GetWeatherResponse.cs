namespace dotnet_tests.Features.Weather.GetWeather;

public record GetWeatherResponse(DateTime Date, double TemperatureC, string Summary)
{
    public double TemperatureF => 32 + (double)(TemperatureC / 0.5556);
}
