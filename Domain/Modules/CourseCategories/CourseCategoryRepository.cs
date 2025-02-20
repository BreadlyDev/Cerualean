using Cerualean.Data;
using Cerualean.Domain.Modules.CourseCategories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cerualean.Domain.Modules.CourseCategories
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

        public async Task<CourseCategory?> DeleteCourseCategory(Guid id)
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
        public async Task<CourseCategory?> GetCourseCategoryById(Guid id)
        {
            return await _context.CourseCategories.FindAsync(id);
        }
        public async Task<CourseCategory?> GetCourseCategoryByTitle(string title)
        {
            return await _context.CourseCategories.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<CourseCategory?> UpdateCourseCategory(Guid id, CourseCategory category)
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

        public async Task<bool> CourseCategoryExists(Guid id)
        {
            return await _context.CourseCategories.AnyAsync(course => course.Id == id);
        }
    }
}