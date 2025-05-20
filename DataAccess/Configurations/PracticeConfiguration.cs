using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class PracticeConfiguration : IEntityTypeConfiguration<PracticeEntity>
{
    public void Configure(EntityTypeBuilder<PracticeEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Title);

        builder.HasOne(p => p.Lesson)
            .WithMany(p => p.Practices)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

