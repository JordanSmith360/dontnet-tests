using DotnetTests.Domain.Models;

namespace DotnetTests.Application.Contracts;

public interface IUserRepository
{
    public Task<int> AddUserAsync(User user);
}
