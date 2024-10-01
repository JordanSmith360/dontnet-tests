using dotnet_tests.Features.Weather;
using dotnet_tests.Features.Weather.GetWeather;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DotnetTests.Api.Features.Weather.GetWeather;

public class GetWeather : EndpointWithoutRequest<Results<Ok<List<GetWeatherResponse>>, NotFound>, GetWeatherMapper>
{
    private readonly MyDbContext _context;

    public GetWeather(MyDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("");
        AllowAnonymous();
        Group<WeatherApiGroup>();
    }

    public override async Task<Results<Ok<List<GetWeatherResponse>>, NotFound>> ExecuteAsync(CancellationToken ct)
    {
        var weatherResponse = await _context.WeatherEntries
           .Select(x => Map.FromEntity(x))
           .ToListAsync(ct);

        if (weatherResponse is null)
        {           
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(weatherResponse);
    }
}

public record GetWeatherResponse(DateTime Date, double TemperatureC, string Summary, int Id)
{
    public double TemperatureF => 32 + (double)(TemperatureC / 0.5556);
}
