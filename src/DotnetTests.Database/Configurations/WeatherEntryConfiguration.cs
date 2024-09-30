using DotnetTests.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetTests.Database.Configurations;

public class WeatherEntryConfiguration : IEntityTypeConfiguration<WeatherEntry>
{
    public void Configure(EntityTypeBuilder<WeatherEntry> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("weird_weather_table_name", t => t.ExcludeFromMigrations());
    }
}
