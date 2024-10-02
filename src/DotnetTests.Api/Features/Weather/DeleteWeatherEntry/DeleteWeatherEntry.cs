using dotnet_tests.Features.Weather;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DotnetTests.Api.Features.Weather.DeleteWeatherEntry;

public class DeleteWeatherEntry(MyDbContext context) 
    : Endpoint<DeleteWeatherEntryRequest, Results<NotFound, Ok>>
{
    public override void Configure()
    {
        Delete("");
        Group<WeatherApiGroup>();
        AllowAnonymous();
    }

    public override async Task<Results<NotFound, Ok>> ExecuteAsync(DeleteWeatherEntryRequest req, CancellationToken ct)
    {
        var result = await context.WeatherEntries
            .Where(x => x.Id == req.Id)
            .ExecuteDeleteAsync(ct);
        
        if (result == 0)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok();
    }
}

public class DeleteWeatherEntryRequest
{
    [QueryParam]
    public int Id { get; set; }
}
