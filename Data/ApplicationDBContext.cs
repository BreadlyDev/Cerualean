using Cerualean.Domain.Modules.CourseCategories;
using Cerualean.Domain.CourseModule;
using Microsoft.EntityFrameworkCore;

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
    }
}