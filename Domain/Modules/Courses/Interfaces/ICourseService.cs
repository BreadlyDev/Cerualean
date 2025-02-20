using Cerualean.Domain.CourseModule.Dtos;

namespace Cerualean.Domain.Modules.Courses.Interfaces
{
    public interface ICourseService
    {
        public Task<List<CourseDto>> GetCourseListByCategory(Guid categoryId);
        public Task<List<CourseDto>> GetCourseList();
        public Task<CourseDto> GetCourseById(Guid id);
        public Task<CourseDto> GetCourseByTitle(string title);
        public Task<CourseDto> CreateCourse(Guid categoryId, CreateCourseDto courseDto);
        public Task<CourseDto> UpdateCourse(Guid id, UpdateCourseDto courseDto);
        public Task<CourseDto> DeleteCourse(Guid id);
    }
}