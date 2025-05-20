using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class UserQuestionConfiguration : IEntityTypeConfiguration<UserQuestionEntity>
{
    public void Configure(EntityTypeBuilder<UserQuestionEntity> builder)
    {
        builder.HasKey(uq => new { uq.UserTestId, uq.QuestionId });

        builder.HasOne(uq => uq.UserTest)
            .WithMany(ut => ut.Questions)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

