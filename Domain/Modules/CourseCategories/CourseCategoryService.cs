using Cerualean.Domain.Common.Exceptions;
using Cerualean.Domain.Modules.CourseCategories.Dtos;
using Cerualean.Domain.Modules.CourseCategories.Helpers;
using Cerualean.Domain.Modules.CourseCategories.Interfaces;

namespace Cerualean.Domain.Modules.CourseCategories
{
    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _categoryRepo;
        public CourseCategoryService(ICourseCategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<CourseCategoryDto> CreateCourseCategory(CreateCourseCategoryDto category)
        {
            var courseModel = await _categoryRepo.CreateCourseCategory(
                category.ToCourseCategoryFromCreateDto()
            );
            return new CourseCategoryDto
            {
                Id = courseModel.Id,
                Title = courseModel.Title,
                Description = courseModel.Description
            };
        }

        public async Task<CourseCategoryDto> DeleteCourseCategory(Guid id)
        {
            var courseModel = await _categoryRepo.DeleteCourseCategory(id);
            
            if (courseModel == null)
            {
                throw new NotFoundException(
                    CourseCategoryExceptionMessages.CourseCategoryNotFound
                );
            }

            return courseModel.ToCourseCategoryDto();
        }

        public async Task<CourseCategoryDto> GetCourseCategoryById(Guid id)
        {
            var courseModel = await _categoryRepo.GetCourseCategoryById(id);

            if (courseModel == null)
            {
                throw new NotFoundException(
                    CourseCategoryExceptionMessages.CourseCategoryNotFound
                );
            }

            return courseModel.ToCourseCategoryDto();
        }

        public async Task<CourseCategoryDto> GetCourseCategoryByTitle(string title)
        {
            var courseModel = await _categoryRepo.GetCourseCategoryByTitle(title);

            if (courseModel == null)
            {
                throw new NotFoundException(
                    CourseCategoryExceptionMessages.CourseCategoryNotFound
                );
            }

            return courseModel.ToCourseCategoryDto();    
        }

        public async Task<List<CourseCategoryDto>> GetCourseCategoryList()
        {
            var courseModelList = await _categoryRepo.GetCourseCategoryList();
            return courseModelList.Select(course => course.ToCourseCategoryDto()).ToList();
        }

        public async Task<CourseCategoryDto> UpdateCourseCategory(Guid id, UpdateCourseCategoryDto category)
        {
            var courseModel = await _categoryRepo.UpdateCourseCategory(
                id, category.ToCourseCategoryFromUpdateDto()
            );

            if (courseModel == null)
            {
                throw new NotFoundException(
                    CourseCategoryExceptionMessages.CourseCategoryNotFound
                );
            }

            return courseModel.ToCourseCategoryDto();    
        }
    }
}