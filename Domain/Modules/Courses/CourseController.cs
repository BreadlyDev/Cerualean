using Cerualean.Domain.Modules.CourseCategories.Helpers;
using Cerualean.Domain.Modules.CourseCategories.Interfaces;
using Cerualean.Domain.CourseModule.Dtos;
using Cerualean.Domain.CourseModule.Helpers;
using Cerualean.Domain.CourseModule.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cerualean.Domain.CourseModule
{
    [Route("/course/category/")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly ICourseCategoryRepository _categoryRepo;
        public CourseController(
            ICourseRepository courseRepo,
            ICourseCategoryRepository categoryRepo
        )
        {
            _courseRepo = courseRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        [Route("{categoryId:guid}/course/list")]
        public async Task<IActionResult> GetListByCategory([FromRoute] Guid categoryId)
        {
            var categoryExists = await _categoryRepo.CourseCategoryExists(categoryId);
            if (!categoryExists)
            {
                return NotFound(CourseCategoryExceptionMessages.CourseCategoryNotFound);
            }

            var coursesModelList = await _courseRepo.GetCourseListByCategory(categoryId);
            var coursesDto = coursesModelList.Select(course => CourseMapper.ToCourseDto(course));

            return Ok(coursesDto);
        }

        [HttpGet]
        [Route("course/{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var courseModel = await _courseRepo.GetCourseById(id);

            if (courseModel == null)
            {
                return NotFound(CourseErrors.CourseNotFoundError);
            }

            return Ok(courseModel);
        }

        [HttpPost]
        [Route("course/{categoryId:guid}/create/")]
        public async Task<IActionResult> Create(
            [FromRoute] Guid categoryId, [FromBody]
            CreateCourseDto courseDto
        )
        {
            var categoryExists = await _categoryRepo.CourseCategoryExists(categoryId);
            if (!categoryExists)
            {
                return NotFound(CourseCategoryExceptionMessages.CourseCategoryNotFound);
            }

            var courseModel = _courseRepo.CreateCourse(
                CourseMapper.ToCourseFromCreateDto(courseDto, categoryId)
            );
            return CreatedAtAction(nameof(GetById), new { id = courseModel.Id }, courseModel);
        }

        [HttpPut]
        [Route("course/{id:guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateCourseDto courseDto
        )
        {
            var categoryExists = await _categoryRepo.CourseCategoryExists(courseDto.CategoryId);

            if (!categoryExists)
            {
                return NotFound(CourseCategoryExceptionMessages.CourseCategoryNotFound);
            }

            var existingCourseModel = await _courseRepo.UpdateCourse(
                id, courseDto.ToCourseFromUpdateDto()
            );

            if (existingCourseModel == null)
            {
                return NotFound(CourseErrors.CourseNotFoundError);
            }

            return Ok(existingCourseModel);
        }

        [HttpDelete]
        [Route("course/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var courseModel = await _courseRepo.DeleteCourse(id);

            if (courseModel == null) 
            {
                return NotFound(CourseErrors.CourseNotFoundError);
            }

            return Ok(courseModel);
        }
    }
}