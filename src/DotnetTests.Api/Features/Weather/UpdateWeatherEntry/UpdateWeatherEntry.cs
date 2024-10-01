using dotnet_tests.Features.Weather;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DotnetTests.Api.Features.Weather.UpdateWeatherEntry;

public class UpdateWeatherEntry(MyDbContext _context, ILogger<UpdateWeatherEntry> _logger) 
    : Endpoint<UpdateWeatherEntryRequest, Results<NotFound, NoContent>, UpdateWeatherEntryMapper>
{
    public override void Configure()
    {
        Put("");
        Group<WeatherApiGroup>();
        AllowAnonymous();
    }

    public override async Task<Results<NotFound, NoContent>> ExecuteAsync(UpdateWeatherEntryRequest req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);

        try
        {
            var dbItem = await _context.WeatherEntries
                .FirstOrDefaultAsync(x => x.Id == entity.Id, ct);

            if (dbItem is null)
            {
                return TypedResults.NotFound();
            }

            _context.Entry(dbItem).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync(ct);

            return TypedResults.NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error has occurred when updating an entry");
            return TypedResults.NotFound();
        }
    }
}

public record UpdateWeatherEntryRequest(int Id, DateTime Date, string Summary, double Temperature);
