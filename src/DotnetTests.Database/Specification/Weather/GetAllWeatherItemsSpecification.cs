using DotnetTests.Database.Models;

namespace DotnetTests.Database.Specification.Weather;

public class GetAllWeatherItemsSpecification : Specification<WeatherEntry>
{
    public GetAllWeatherItemsSpecification(int? pageNumber = null, int? pageSize = null) 
        : base()
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
