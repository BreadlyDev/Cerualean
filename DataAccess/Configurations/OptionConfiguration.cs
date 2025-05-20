using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class OptionConfiguration : IEntityTypeConfiguration<OptionEntity>
{
    public void Configure(EntityTypeBuilder<OptionEntity> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(o => o.Question)
            .WithMany(q => q.Options)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

