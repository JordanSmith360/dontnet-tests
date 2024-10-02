using dotnet_tests.Features.Weather;
using dotnet_tests.Features.Weather.GetWeather;
using DotnetTests.Database.Specification;
using DotnetTests.Database.Specification.Weather;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DotnetTests.Api.Features.Weather.GetWeather;

public class GetWeather(MyDbContext context) 
    : EndpointWithoutRequest<Results<Ok<List<GetWeatherResponse>>, NotFound>, GetWeatherMapper>
{    public override void Configure()
    {
        Get("");
        AllowAnonymous();
        Group<WeatherApiGroup>();
    }

    public override async Task<Results<Ok<List<GetWeatherResponse>>, NotFound>> ExecuteAsync(CancellationToken ct)
    {
        var weatherResponse = await context.WeatherEntries
            .UseSpecification(new GetAllWeatherItemsSpecification(1, 2))
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
