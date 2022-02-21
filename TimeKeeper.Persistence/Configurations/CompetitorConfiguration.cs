using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Persistence.Configurations;

internal class CompetitorConfiguration : IEntityTypeConfiguration<Competitor>
{
    public void Configure(EntityTypeBuilder<Competitor> builder)
    {
        _ = builder.Property(competitor => competitor.Name).HasMaxLength(50);
        _ = builder.HasDiscriminator<string>("Category")
                .HasValue<Female>("Female")
                .HasValue<Male>("Male");
    }
}