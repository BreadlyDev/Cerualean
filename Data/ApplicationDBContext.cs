using Cerualean.Domain.Modules.CourseCategories;
using Cerualean.Domain.CourseModule;
using Microsoft.EntityFrameworkCore;
using Cerualean.Domain.Modules.Lessons;

namespace Cerualean.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>()
                .HasOne(lesson => lesson.NextLesson)
                .WithOne()
                .HasForeignKey<Lesson>(lesson => lesson.NextLessonId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Lesson>()
                .HasOne(lesson => lesson.PreviousLesson)
                .WithOne()
                .HasForeignKey<Lesson>(lesson => lesson.PreviousLessonId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}