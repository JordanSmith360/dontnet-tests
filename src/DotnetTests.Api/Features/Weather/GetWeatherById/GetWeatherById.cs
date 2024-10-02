using dotnet_tests.Features.Weather;
using dotnet_tests.Features.Weather.GetWeather;
using DotnetTests.Database.Specification.Weather;
using Microsoft.AspNetCore.Http.HttpResults;
using DotnetTests.Database.Specification;
using Microsoft.EntityFrameworkCore;
using DotnetTests.Api.Features.Weather.GetWeather;

namespace DotnetTests.Api.Features.Weather.GetWeatherById;

public class GetWeatherById(MyDbContext context)
    : Endpoint<GetWeatherByIdRequest, Results<Ok<GetWeatherResponse>, NotFound>, GetWeatherMapper>
{
    public override void Configure()
    {
        Get("/{Id}");
        AllowAnonymous();
        Group<WeatherApiGroup>();
    }

    public override async Task<Results<Ok<GetWeatherResponse>, NotFound>> ExecuteAsync(GetWeatherByIdRequest req, CancellationToken ct)
    {
        var weatherResponse = await context.WeatherEntries
            //.UseSpecification(new GetWeatherItemsByIdSpecification(req.Id))
            .Where(x => x.Id == req.Id)
            .Select(x => Map.FromEntity(x))
            .FirstOrDefaultAsync(ct);

        if (weatherResponse is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(weatherResponse);
    }
}

public record GetWeatherByIdRequest(int Id);
