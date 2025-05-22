using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class UserOptionConfiguration : IEntityTypeConfiguration<UserOptionEntity>
{
    public void Configure(EntityTypeBuilder<UserOptionEntity> builder)
    {
        builder.HasKey(uo => new { uo.UserQuestionId, uo.OptionId });

        builder.HasOne(uo => uo.UserQuestion)
            .WithMany(uq => uq.SelectedOptions)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

