using Cerualean.Domain.Modules.CourseCategories.Dtos;

namespace Cerualean.Domain.Modules.CourseCategories.Interfaces
{
    public interface ICourseCategoryService
    {
        public Task<List<CourseCategoryDto>> GetCourseCategoryList();
        public Task<CourseCategoryDto> GetCourseCategoryById(int id);
        public Task<CourseCategoryDto> GetCourseCategoryByTitle(string title);
        public Task<CourseCategoryDto> CreateCourseCategory(CreateCourseCategoryDto categoryDto);
        public Task<CourseCategoryDto> UpdateCourseCategory(int id, UpdateCourseCategoryDto categoryDto);
        public Task<CourseCategoryDto> DeleteCourseCategory(int id);
    }
}