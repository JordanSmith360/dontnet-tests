using DotnetTests.Application.Features.Users;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetTests.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
