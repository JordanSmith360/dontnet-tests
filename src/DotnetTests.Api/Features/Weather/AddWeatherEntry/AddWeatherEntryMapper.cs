using DotnetTests.Database.Models;

namespace dotnet_tests.Features.Weather.AddWeatherEntry;

public class AddWeatherEntryMapper : RequestMapper<AddWeatherEntryRequest, WeatherEntry>
{
    public override WeatherEntry ToEntity(AddWeatherEntryRequest r)
    {
        return new WeatherEntry()
        {
            Date = r.DateTime,
            TemperatureCelsius = r.Temperature,
            Summary = r.Summary,
        };
    }
}
