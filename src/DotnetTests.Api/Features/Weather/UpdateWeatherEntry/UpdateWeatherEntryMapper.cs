using DotnetTests.Database.Models;

namespace DotnetTests.Api.Features.Weather.UpdateWeatherEntry;

public class UpdateWeatherEntryMapper : RequestMapper<UpdateWeatherEntryRequest, WeatherEntry>
{
    public override WeatherEntry ToEntity(UpdateWeatherEntryRequest r)
    {
        return new WeatherEntry
        {
            Id = r.Id,
            Date = r.Date,
            Summary = r.Summary,
            TemperatureCelsius = (decimal) r.Temperature
        };
    }
}
