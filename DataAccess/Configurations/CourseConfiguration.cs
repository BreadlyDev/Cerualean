using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Title).IsUnique();

        builder.HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

