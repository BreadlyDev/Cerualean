using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class UserPracticeConfiguration : IEntityTypeConfiguration<UserPracticeEntity>
{
	public void Configure(EntityTypeBuilder<UserPracticeEntity> builder)
	{
		builder.HasKey(up => new { up.UserId, up.PracticeId });
	}
}
