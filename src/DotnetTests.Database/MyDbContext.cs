using DotnetTests.Database.Models;
using DotnetTests.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DotnetTests.Database;

public class MyDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public DbSet<WeatherEntry> WeatherEntries { get; set; }
    public DbSet<User> Users { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
