using dotnet_tests.Features.Weather.GetWeather;
using Microsoft.EntityFrameworkCore;

namespace DotnetTests.Api.Features.Weather.GetWeather;

public class GetWeather : EndpointWithoutRequest<List<GetWeatherResponse>, GetWeatherMapper>
{
    private readonly MyDbContext _context;

    public GetWeather(MyDbContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("/weather");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var weatherResponse = await _context.WeatherEntries
           .Select(x => Map.FromEntity(x))
           .ToListAsync(ct);

        if (weatherResponse is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendAsync(weatherResponse, cancellation: ct);
    }
}
