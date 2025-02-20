using Cerualean.Domain.Common.Exceptions;
using Cerualean.Domain.Modules.CourseCategories.Dtos;
using Cerualean.Domain.Modules.CourseCategories.Helpers;
using Cerualean.Domain.Modules.CourseCategories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cerualean.Domain.Modules.CourseCategories
{
    [Route("/course/category/")]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryService _categoryService;
        public CourseCategoryController(ICourseCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _categoryService.GetCourseCategoryList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _categoryService.GetCourseCategoryById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("create/")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCourseCategoryDto categoryDto
        )
        {
            var categoryModel = await _categoryService.CreateCourseCategory(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateCourseCategoryDto categoryDto
        )
        {
            try
            {
                return Ok(await _categoryService.UpdateCourseCategory(id, categoryDto));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _categoryService.DeleteCourseCategory(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}