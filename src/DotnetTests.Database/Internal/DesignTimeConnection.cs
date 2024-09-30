using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DotnetTests.Database.Internal;

internal class DesignTimeConnection : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<MyDbContext>()
               .UseSqlServer("Server=localhost,1433;Database=TestDatabase;User Id=sa;Password=P@SSW0RD;Encrypt=False",
                   opts => opts.EnableRetryOnFailure()
                       .CommandTimeout(1800)
               )
               .Options;

        return new MyDbContext(options);
    }
}
