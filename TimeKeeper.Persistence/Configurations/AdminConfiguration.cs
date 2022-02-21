using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Persistence.Configurations;

internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        _ = builder.Property(admin => admin.Username).HasMaxLength(50);
        _ = builder.Property(admin => admin.Password).HasMaxLength(50);
    }
}