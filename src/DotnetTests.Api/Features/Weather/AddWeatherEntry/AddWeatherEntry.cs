
namespace dotnet_tests.Features.Weather.AddWeatherEntry;

public class AddWeatherEntry : Endpoint<AddWeatherEntryRequest, AddWeatherEntryResponse, AddWeatherEntryMapper>
{
    private readonly MyDbContext _context;
    private ILogger<AddWeatherEntry> _logger;
    public AddWeatherEntry(MyDbContext context, ILogger<AddWeatherEntry> logger)
    {
        _context = context;
        _logger = logger;
    }

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
            await _context.WeatherEntries.AddAsync(dbEntity);
            await _context.SaveChangesAsync(ct);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occured when adding the DB entry");
            await SendErrorsAsync(500, ct);
            return;
        }

        await SendAsync(new AddWeatherEntryResponse(dbEntity.Id), cancellation: ct);
    }
}

public record AddWeatherEntryRequest(DateTime DateTime, int Temperature, string Summary);
public record AddWeatherEntryResponse(int Id);