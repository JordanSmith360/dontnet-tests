using DotnetTests.Database.Models;
using DotnetTests.Domain.Models;

namespace DotnetTests.Api.Features.Users;

public class CreateUserMapper : RequestMapper<CreateUserRequest, User>
{
    public override User ToEntity(CreateUserRequest r)
    {
        return new User()
        {
            Name = r.Name,
            Surname = r.Surname,
            Age = r.Age,
            Email = r.Email,
            FavoriteBrand = FavoriteBrands.Adidas,
        };
    }
}
