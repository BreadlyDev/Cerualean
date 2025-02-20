using Cerualean.Domain.Common.Exceptions;
using Cerualean.Domain.CourseModule.Dtos;
using Cerualean.Domain.CourseModule.Helpers;
using Cerualean.Domain.CourseModule.Interfaces;
using Cerualean.Domain.Modules.CourseCategories.Interfaces;
using Cerualean.Domain.Modules.Courses.Interfaces;

namespace Cerualean.Domain.Modules.Courses
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepo;
        private readonly ICourseCategoryRepository _categoryRepo;

        public CourseService(
            ICourseRepository courseRepo,
            ICourseCategoryRepository categoryRepo
        )
        {
            _courseRepo = courseRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<CourseDto> CreateCourse(Guid categoryId, CreateCourseDto courseDto)
        {
            var categoryExists = await _categoryRepo.CourseCategoryExists(categoryId);

            if (!categoryExists)
            {
                throw new NotFoundException(CourseExceptionMessages.CourseNotFoundError);
            }

            var courseModel = await _courseRepo.CreateCourse(
                courseDto.ToCourseFromCreateDto(categoryId)
            );

            return courseModel.ToCourseDto();
        }

        public async Task<CourseDto> DeleteCourse(Guid id)
        {
            var courseModel = await _courseRepo.DeleteCourse(id);

            if (courseModel == null)
            {
                throw new NotFoundException(CourseExceptionMessages.CourseNotFoundError);
            }

            return courseModel.ToCourseDto();
        }

        public async Task<CourseDto> GetCourseById(Guid id)
        {
            var courseModel = await _courseRepo.GetCourseById(id);

            if (courseModel == null)
            {
                throw new NotFoundException(CourseExceptionMessages.CourseNotFoundError);
            }

            return courseModel.ToCourseDto();
        }

        public async Task<CourseDto> GetCourseByTitle(string title)
        {
            var courseModel = await _courseRepo.GetCourseByTitle(title);

            if (courseModel == null)
            {
                throw new NotFoundException(CourseExceptionMessages.CourseNotFoundError);
            }

            return courseModel.ToCourseDto();
        }

        public async Task<List<CourseDto>> GetCourseList()
        {
            var courseModelList = await _courseRepo.GetCourseList();
            return courseModelList.Select(course => course.ToCourseDto()).ToList();
        }

        public async Task<List<CourseDto>> GetCourseListByCategory(Guid categoryId)
        {
            var categoryExists = await _categoryRepo.CourseCategoryExists(categoryId);

            if (!categoryExists)
            {
                throw new NotFoundException(CourseExceptionMessages.CourseNotFoundError);
            }

            var courseModelList = await _courseRepo.GetCourseListByCategory(categoryId);
            return courseModelList.Select(course => course.ToCourseDto()).ToList();
        }

        public async Task<CourseDto> UpdateCourse(Guid id, UpdateCourseDto courseDto)
        {
            
            var courseModel = await _courseRepo.UpdateCourse(id, courseDto.ToCourseFromUpdateDto());

            if (courseModel == null)
            {
                throw new NotFoundException(CourseExceptionMessages.CourseNotFoundError);
            }

            return courseModel.ToCourseDto();
        }
    }
}