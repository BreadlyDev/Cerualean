using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class TestConfiguration : IEntityTypeConfiguration<TestEntity>
{
    public void Configure(EntityTypeBuilder<TestEntity> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.Title).IsUnique();

        builder.HasMany(t => t.Questions)
            .WithOne(q => q.Test)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

