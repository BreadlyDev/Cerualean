using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
{
    public void Configure(EntityTypeBuilder<LessonEntity> builder)
    {
        builder.HasKey(l => l.Id);
        builder.HasIndex(l => l.Title).IsUnique();

        builder.HasOne(l => l.Course)
            .WithMany(c => c.Lessons)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(l => l.Tests)
            .WithOne(t => t.Lesson)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(l => l.Practices)
            .WithOne(t => t.Lesson)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(l => l.Theories)
            .WithOne(t => t.Lesson)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(lesson => lesson.NextLesson)
            .WithOne()
            .HasForeignKey<LessonEntity>(lesson => lesson.NextLessonId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(lesson => lesson.PreviousLesson)
            .WithOne()
            .HasForeignKey<LessonEntity>(lesson => lesson.PreviousLessonId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

