using Cerualean.Data;
using Cerualean.Domain.CourseCategoryModule.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cerualean.Domain.CourseCategoryModule
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CourseCategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<CourseCategory> CreateCourseCategory(CourseCategory category)
        {
            await _context.CourseCategories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<CourseCategory?> DeleteCourseCategory(int id)
        {
            var category = await _context.CourseCategories.FindAsync(id);

            if (category == null)
            {
                return null;
            }

            _context.CourseCategories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<List<CourseCategory>> GetCourseCategoryList()
        {
            return await _context.CourseCategories.ToListAsync();
        }
        public async Task<CourseCategory?> GetCourseCategoryById(int id)
        {
            return await _context.CourseCategories.FindAsync(id);
        }
        public async Task<CourseCategory?> GetCourseCategoryByTitle(string name)
        {
            return await _context.CourseCategories.FirstOrDefaultAsync(x => x.Title == name);
        }

        public async Task<CourseCategory?> UpdateCourseCategory(int id, CourseCategory category)
        {
            var existingCategory = await _context.CourseCategories.FindAsync(id);

            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Title = category.Title;
            existingCategory.Description = category.Description;

            await _context.SaveChangesAsync();
            return category;
        }
    }
}