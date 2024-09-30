using DotnetTests.Database.Models;

namespace dotnet_tests.Features.Weather.GetWeather;

public class GetWeatherMapper : ResponseMapper<GetWeatherResponse, WeatherEntry>
{
    public override GetWeatherResponse FromEntity(WeatherEntry weatherEntry)
    {
        return new GetWeatherResponse(weatherEntry.Date,
            (double)weatherEntry.TemperatureCelsius,
            weatherEntry.Summary);
    }
}
