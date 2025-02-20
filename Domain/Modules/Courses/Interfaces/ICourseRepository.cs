namespace Cerualean.Domain.CourseModule.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<Course>> GetCourseListByCategory(int categoryId);
        public Task<List<Course>> GetCourseList();
        public Task<Course?> GetCourseById(int id);
        public Task<Course?> GetCourseByTitle(string title);
        public Task<Course> CreateCourse(Course course);
        public Task<Course?> UpdateCourse(int id, Course course);
        public Task<Course?> DeleteCourse(int id);
        public Task<bool> CourseExists(int id);
    }
}