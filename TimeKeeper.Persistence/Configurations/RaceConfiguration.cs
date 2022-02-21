using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Persistence.Configurations;

internal class RaceConfiguration : IEntityTypeConfiguration<Race>
{
    public void Configure(EntityTypeBuilder<Race> builder)
    {
        _ = builder.Property(race => race.Name).HasMaxLength(50);
    }
}