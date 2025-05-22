using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class UserLessonConfiguration : IEntityTypeConfiguration<UserLessonEntity>
{
	public void Configure(EntityTypeBuilder<UserLessonEntity> builder)
	{
		builder.HasKey(ul => new { ul.UserId, ul.LessonId });

		// builder.HasOne(ul => ul.User)
		// 	.WithMany()
		// 	.HasForeignKey(ul => ul.UserId)
		// 	.OnDelete(DeleteBehavior.Cascade);

		// builder.HasOne(ul => ul.Lesson)
		// 	.WithMany()
		// 	.HasForeignKey(ul => ul.LessonId)
		// 	.OnDelete(DeleteBehavior.Cascade);
	}
}
