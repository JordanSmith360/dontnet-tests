using DotnetTests.Database.Models;

namespace DotnetTests.Database.Specification.Weather;

public class GetWeatherItemsByIdSpecification : Specification<WeatherEntry>
{
    public GetWeatherItemsByIdSpecification(int Id) 
        : base((w) => w.Id == Id)
    {
        
    }
}
