using Cerualean.Domain.CourseModule.Dtos;
using Microsoft.AspNetCore.Mvc;
using Cerualean.Domain.Modules.Courses.Interfaces;
using Cerualean.Domain.Common.Exceptions;

namespace Cerualean.Domain.CourseModule
{
    [Route("/course/category/")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("{categoryId:guid}/course/list")]
        public async Task<IActionResult> GetListByCategory([FromRoute] Guid categoryId)
        {
            try
            {
                return Ok(await _courseService.GetCourseListByCategory(categoryId));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("course/{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _courseService.GetCourseById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("{categoryId:guid}/create/")]
        public async Task<IActionResult> Create(
            [FromRoute] Guid categoryId,
            [FromBody] CreateCourseDto courseDto
        )
        {
            try
            {
                var courseModel = _courseService.CreateCourse(categoryId, courseDto);
                return CreatedAtAction(nameof(GetById), new { id = courseModel.Id }, courseModel);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut, HttpPatch]
        [Route("course/{id:guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateCourseDto courseDto
        )
        {
            try
            {
                return Ok(await _courseService.UpdateCourse(id, courseDto));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        [Route("course/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try 
            {
                return Ok(await _courseService.DeleteCourse(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}