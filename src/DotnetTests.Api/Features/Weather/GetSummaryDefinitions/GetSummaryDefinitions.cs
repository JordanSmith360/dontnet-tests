using dotnet_tests.Features.Weather;

namespace DotnetTests.Api.Features.Weather.GetSummaryChoices;

public class GetSummaryDefinitions : EndpointWithoutRequest<List<GetSummaryDefinitionsResponse>>
{
    private string[] _summaryOptions =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public override void Configure()
    {
        Get("/summary-definitions");
        AllowAnonymous();
        Group<WeatherApiGroup>();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = _summaryOptions.Select((x, i) => new GetSummaryDefinitionsResponse(i + 1, x))
            .ToList();

        await SendAsync(response, cancellation: ct);
    }
}

public record GetSummaryDefinitionsResponse(int Id, string Summary);
