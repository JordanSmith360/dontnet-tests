using DotnetTests.Database.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotnetTests.Api.Features.Users;

// Request object
// Query Params filtering
// Pagination
// Validation of request
// Unit tests

public class GetUser(MyDbContext dbContext) 
    : Endpoint<GetUserRequest, Ok<PageResponse<GetUserResponse>>, GetUserMapper>
{
    public override void Configure()
    {
        Get("/users");
        AllowAnonymous();
    }

    public override async Task<Ok<PageResponse<GetUserResponse>>> ExecuteAsync(GetUserRequest req, CancellationToken ct)
    {
        var querable = dbContext.Users
            .AsQueryable();

        if (req.Age is not null)
        {
            querable = querable.Where(x => x.Age == req.Age);
        }

        var countTotals = await querable.CountAsync(ct);

        if (req.PageNumber is not null &&
            req.PageSize is not null)
        {
            querable = querable
                .Skip(((int)req.PageNumber - 1) * (int)req.PageSize)
                .Take((int)req.PageSize);
        }

        var allUsers = await querable
            .ToListAsync(ct);

        var dtos = allUsers.Select(Map.FromEntity)
            .ToList();

        var pagedResponse = new PageResponse<GetUserResponse>(dtos, req.PageNumber ?? 0, req.PageSize ?? 0, countTotals);

        return TypedResults.Ok(pagedResponse);
    }
}

public class GetUserRequest : PageRequest
{
    [QueryParam]
    public int? Age { get; set; }
}

public record GetUserResponse(int Id, string Name, string Surname, string Email);
public class PageRequest
{
    [QueryParam]
    public int? PageNumber { get; set; }
    [QueryParam]
    public int? PageSize { get; set; }
}

public class PageResponse <T>
{
    public PageResponse(List<T> data, int pageNumber, int pageSize, int totalRecords)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        IsPrevious = pageNumber != 1;
        IsNext = totalRecords > pageNumber * pageSize;
    }

    public bool IsPrevious { get; set; }
    public bool IsNext { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public List<T> Data { get; set; }
}

public class GetUserMapper : ResponseMapper<GetUserResponse, User>
{
    public override GetUserResponse FromEntity(User e)
    {
        return new GetUserResponse(e.Id,
            e.Name,
            e.Surname,
            e.Email);
    }
}