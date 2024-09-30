namespace dotnet_tests.Features.Weather;

public class WeatherApiGroup : Group
{
    public WeatherApiGroup()
    {
        Configure("weather", ep =>
        {
            ep.Description(x => x
              .Produces(401)
              .WithTags("Weather"));
        });
    }
}
