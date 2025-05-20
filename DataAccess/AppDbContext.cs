using DataAccess.Authorization;
using DataAccess.Configurations;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccess;

public class AppDbContext(
	DbContextOptions<AppDbContext> options,
	IOptions<AuthorizationOptions> authOptions
) : DbContext(options)
{
	public DbSet<RoleEntity> Roles { get; set; }
	public DbSet<PermissionEntity> Permissions { get; set; }
	public DbSet<RolePermissionEntity> RolePermissions { get; set; }
	public DbSet<UserEntity> Users { get; set; }
	public DbSet<CourseEntity> Courses { get; set; }
	public DbSet<LessonEntity> Lessons { get; set; }
	public DbSet<PracticeEntity> Practices { get; set; }
	public DbSet<TheorieEntity> Theories { get; set; }
	public DbSet<TestEntity> Tests { get; set; }
	public DbSet<QuestionEntity> Questions { get; set; }
	public DbSet<OptionEntity> Options { get; set; }
	public DbSet<UserLessonEntity> UserLessons { get; set; }
	public DbSet<UserPracticeEntity> UserPractices { get; set; }
	public DbSet<UserTestEntity> UserTests { get; set; }
	public DbSet<UserQuestionEntity> UserQuestions { get; set; }
	public DbSet<UserOptionEntity> UserOptions { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

		modelBuilder.ApplyConfiguration(new RoleConfiguration());
		modelBuilder.ApplyConfiguration(new PermissionConfiguration());
		modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
		modelBuilder.ApplyConfiguration(new UserConfiguration());
		modelBuilder.ApplyConfiguration(new CourseConfiguration());
		modelBuilder.ApplyConfiguration(new LessonConfiguration());
		modelBuilder.ApplyConfiguration(new TheorieConfiguration());
		modelBuilder.ApplyConfiguration(new PracticeConfiguration());
		modelBuilder.ApplyConfiguration(new TestConfiguration());
		modelBuilder.ApplyConfiguration(new QuestionConfiguration());
		modelBuilder.ApplyConfiguration(new OptionConfiguration());
		modelBuilder.ApplyConfiguration(new UserTestConfiguration());
		modelBuilder.ApplyConfiguration(new UserQuestionConfiguration());
		modelBuilder.ApplyConfiguration(new UserOptionConfiguration());
		modelBuilder.ApplyConfiguration(new UserLessonConfiguration());
		modelBuilder.ApplyConfiguration(new UserPracticeConfiguration());


		base.OnModelCreating(modelBuilder);
	}
}

