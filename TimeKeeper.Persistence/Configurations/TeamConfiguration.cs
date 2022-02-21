using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Persistence.Configurations;

internal class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        _ = builder.Property(team => team.Name).HasMaxLength(100);
    }
}