using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Persistence.Configurations;

internal class StageConfiguration : IEntityTypeConfiguration<Stage>
{
    public void Configure(EntityTypeBuilder<Stage> builder)
    {
        _ = builder.Property(stage => stage.Name).HasMaxLength(50);
    }
}