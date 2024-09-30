using DotnetTests.Database.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DotnetTests.Database;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlContext(this IServiceCollection serviceCollection, string sqlConfigPrefix = "SQL_CONFIG")
    {
        serviceCollection.AddOptions<SqlConfig>()
            .BindConfiguration(sqlConfigPrefix);

        serviceCollection.AddDbContext<MyDbContext>((sp, opt) =>
        {
            var sqlConfig = sp.GetRequiredService<IOptions<SqlConfig>>();
            opt.UseSqlServer(BuildConnectionString(sqlConfig.Value), cfg => cfg.EnableRetryOnFailure());
        });            

        return serviceCollection;
    }

    private static string BuildConnectionString(SqlConfig connectionDetails)
    {
        return @$"Server=tcp:{connectionDetails.Server},1433;Initial Catalog={connectionDetails.DatabaseName};
Persist Security Info=False;User ID={connectionDetails.User};Password={connectionDetails.Password};MultipleActiveResultSets=False;
Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
