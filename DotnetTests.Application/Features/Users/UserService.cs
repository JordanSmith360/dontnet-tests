using DotnetTests.Application.Contracts;
using DotnetTests.Domain.Models;

namespace DotnetTests.Application.Features.Users;

public interface IUserService
{
    Task<int> CreateUserAsync(User userReq);
}

public class UserService(IUserRepository repository) : IUserService
{
    public async Task<int> CreateUserAsync(User userReq)
    {
        try
        {
            // Calc1 
            // Bis 1
            var response = await repository.AddUserAsync(userReq);
            return response;
        } 
        catch(Exception)
        {
            return -1;
        }
    }
}
