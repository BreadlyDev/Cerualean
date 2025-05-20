using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<QuestionEntity>
{
    public void Configure(EntityTypeBuilder<QuestionEntity> builder)
    {
        builder.HasKey(q => q.Id);

        builder.HasOne(q => q.Test)
            .WithMany(t => t.Questions)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(q => q.Options)
            .WithOne(o => o.Question)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

