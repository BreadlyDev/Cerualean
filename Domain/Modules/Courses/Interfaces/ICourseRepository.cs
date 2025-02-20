namespace Cerualean.Domain.CourseModule.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<Course>> GetCourseListByCategory(Guid categoryId);
        public Task<List<Course>> GetCourseList();
        public Task<Course?> GetCourseById(Guid id);
        public Task<Course?> GetCourseByTitle(string title);
        public Task<Course> CreateCourse(Course course);
        public Task<Course?> UpdateCourse(Guid id, Course course);
        public Task<Course?> DeleteCourse(Guid id);
    }
}