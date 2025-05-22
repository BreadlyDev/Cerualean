using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class UserTestConfiguration : IEntityTypeConfiguration<UserTestEntity>
{
    public void Configure(EntityTypeBuilder<UserTestEntity> builder)
    {
        builder.HasKey(ut => new { ut.UserId, ut.TestId });

        builder.HasMany(ut => ut.Questions)
            .WithOne(uq => uq.UserTest)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

