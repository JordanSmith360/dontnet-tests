
namespace dotnet_tests.Features.Weather.AddWeatherEntry;

public class AddWeatherEntry(MyDbContext context, ILogger<AddWeatherEntry> logger) 
    : Endpoint<AddWeatherEntryRequest, AddWeatherEntryResponse, AddWeatherEntryMapper>
{
    public override void Configure()
    {
        Post("");
        AllowAnonymous();
        Group<WeatherApiGroup>();
    }

    public override async Task HandleAsync(AddWeatherEntryRequest req, CancellationToken ct)
    {
        var dbEntity = Map.ToEntity(req);
        try
        {
            await context.WeatherEntries.AddAsync(dbEntity);
            await context.SaveChangesAsync(ct);
        }
        catch(Exception ex)
        {
            logger.LogError(ex, "An error occured when adding the DB entry");
            await SendErrorsAsync(500, ct);
            return;
        }

        await SendAsync(new AddWeatherEntryResponse(dbEntity.Id), cancellation: ct);
    }
}

public record AddWeatherEntryRequest(DateTime DateTime, int Temperature, string Summary);
public record AddWeatherEntryResponse(int Id);