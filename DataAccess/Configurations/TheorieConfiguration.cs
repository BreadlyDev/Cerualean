using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class TheorieConfiguration : IEntityTypeConfiguration<TheorieEntity>
{
    public void Configure(EntityTypeBuilder<TheorieEntity> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.Title);

        builder.HasOne(t => t.Lesson)
            .WithMany(l => l.Theories)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

