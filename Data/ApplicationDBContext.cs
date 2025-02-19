using Cerualean.Domain.CourseCategoryModule;
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
    }
}