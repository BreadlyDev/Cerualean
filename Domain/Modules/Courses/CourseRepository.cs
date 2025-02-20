using Cerualean.Data;
using Cerualean.Domain.CourseModule.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cerualean.Domain.CourseModule
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDBContext _context;
        public CourseRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Course> CreateCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course?> DeleteCourse(Guid id)
        {
            var courseModel = await _context.Courses.FindAsync(id);

            if(courseModel == null) 
            {
                return null;
            }

            _context.Courses.Remove(courseModel);
            return courseModel;
        }

        public async Task<Course?> GetCourseById(Guid id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<Course?> GetCourseByTitle(string title)
        {
            return await _context.Courses.FirstOrDefaultAsync(course => course.Title == title);
        }

        public async Task<List<Course>> GetCourseList()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<List<Course>> GetCourseListByCategory(Guid categoryId)
        {
            return await _context.Courses
                .Where(course => course.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Course?> UpdateCourse(Guid id, Course course)
        { 
            var existingCourseModel = await _context.Courses.FindAsync(id);

            if(existingCourseModel == null) 
            {
                return null;
            }

            existingCourseModel.Title = course.Title;
            existingCourseModel.Description = course.Description;
            existingCourseModel.Duration = course.Duration;
            existingCourseModel.Price = course.Price;
            existingCourseModel.CategoryId = course.CategoryId;

            await _context.SaveChangesAsync();
            return existingCourseModel;
        }
    }
}