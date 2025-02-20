namespace Cerualean.Domain.Modules.CourseCategories.Interfaces
{
    public interface ICourseCategoryRepository
    {
        public Task<List<CourseCategory>> GetCourseCategoryList();
        public Task<CourseCategory?> GetCourseCategoryById(Guid id);
        public Task<CourseCategory?> GetCourseCategoryByTitle(string title);
        public Task<CourseCategory> CreateCourseCategory(CourseCategory category);
        public Task<CourseCategory?> UpdateCourseCategory(Guid id, CourseCategory category);
        public Task<CourseCategory?> DeleteCourseCategory(Guid id);
        public Task<bool> CourseCategoryExists(Guid id);
    }
}