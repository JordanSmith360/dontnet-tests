using DotnetTests.Application.Features.Users;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DotnetTests.Api.Features.Users;

public class CreateUser(IUserService userService) : Endpoint<CreateUserRequest, Ok<int>, CreateUserMapper>
{
    public override void Configure()
    {
        Post("/users");
        AllowAnonymous();
    }

    public override async Task<Ok<int>> ExecuteAsync(CreateUserRequest req, CancellationToken ct)
    {
        var entity = Map.ToEntity(req);
        var res = await userService.CreateUserAsync(entity);
        return TypedResults.Ok(res);
    }
}

public record CreateUserRequest(string Name, string Surname, int Age, string FavBrand, string Email);
