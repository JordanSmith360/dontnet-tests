using DotnetTests.Application.Contracts;
using DotnetTests.Domain.Models;

namespace DotnetTests.Database.Repositories;

internal class UserRepository(MyDbContext dbContext) : IUserRepository
{
    public async Task<int> AddUserAsync(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user.Id;
    }
}
