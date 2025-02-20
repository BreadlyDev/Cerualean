using Cerualean.Domain.CourseModule.Dtos;

namespace Cerualean.Domain.Modules.Courses.Interfaces
{
    public interface ICourseService
    {
        public Task<List<CourseDto>> GetCourseListByCategory(int categoryId);
        public Task<List<CourseDto>> GetCourseList();
        public Task<CourseDto> GetCourseById(int id);
        public Task<CourseDto> GetCourseByTitle(string title);
        public Task<CourseDto> CreateCourse(int categoryId, CreateCourseDto courseDto);
        public Task<CourseDto> UpdateCourse(int id, UpdateCourseDto courseDto);
        public Task<CourseDto> DeleteCourse(int id);
    }
}